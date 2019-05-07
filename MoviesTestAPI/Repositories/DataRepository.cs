using Dapper;
using Microsoft.Extensions.Configuration;
using MoviesTestAPI.Interfaces;
using MoviesTestAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MoviesTestAPI.Repositories
{
    public class DataRepository: IDataRepository
    {
        private readonly IConfiguration _config;

        public DataRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("MoviesConnectionString"));
            }
        }

        public async Task<List<Movie>> GetMovieData()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT MovieId, Name, Rating, Category, DateCreated, DateModified FROM MovieTable";
                conn.Open();
                var result = await conn.QueryAsync<Movie>(sQuery);
                return result.AsList();
            }
        }

        public async void DeleteMovie(int movieId)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "DELETE FROM MovieTable WHERE MovieId = @MovieId";
                conn.Open();
                await conn.ExecuteAsync(sQuery, new { MovieId = movieId });
            }
        }

        public async void AddMovie(Movie movie)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "INSERT INTO MovieTable (Name, Rating, Category) VALUES (@Name, @Rating, @Category)";
                conn.Open();
                await conn.ExecuteAsync(sQuery, new
                {
                    Name = movie.Name,
                    Rating = movie.Rating,
                    Category = movie.Category
                });
            }
        }

        public async void EditMovie(Movie movie)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "UPDATE MovieTable SET Name = @Name, Rating = @Rating, Category = @Category, DateModified = @DateModified where MovieId = @MovieId";
                conn.Open();
                await conn.ExecuteAsync(sQuery, new
                {
                    MovieID = movie.MovieID,
                    Name = movie.Name,
                    Rating = movie.Rating,
                    Category = movie.Category,
                    DateModified = movie.DateModified
                });
            }
        }
    }
}
