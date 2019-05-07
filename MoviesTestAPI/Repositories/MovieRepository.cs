using MoviesTestAPI.Interfaces;
using MoviesTestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesTestAPI.Repositories
{
    public class MovieRepository: IMovieRepository
    {
        private readonly IDataRepository _dataRepository;

        public MovieRepository(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task<List<Movie>> GetMovies()
        {
            return await _dataRepository.GetMovieData();
        }

        public List<MovieStats> GetMovieStats()
        {
            var data = _dataRepository.GetMovieData();

            return data.Result.GroupBy(x => x.Rating)
            .Select(x => new MovieStats
            {
                Rating = x.Key,
                totalRatings = x.Count()
            }).ToList();
        }

        public void DeleteMovie(int movieId)
        {
            _dataRepository.DeleteMovie(movieId);
        }

        public void AddMovie(Movie movie)
        {
            _dataRepository.AddMovie(movie);
        }

        public void EditMovie(Movie movie)
        {
            movie.DateModified = DateTime.Now;
            _dataRepository.EditMovie(movie);
        }
    }
}
