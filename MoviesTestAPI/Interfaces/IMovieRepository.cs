using MoviesTestAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesTestAPI.Interfaces
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetMovies();
        List<MovieStats> GetMovieStats();
        void DeleteMovie(int movieId);
        void AddMovie(Movie movie);
        void EditMovie(Movie movie);
    }
}
