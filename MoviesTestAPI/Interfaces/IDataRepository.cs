using MoviesTestAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesTestAPI.Interfaces
{
    public interface IDataRepository
    {
        Task<List<Movie>> GetMovieData();
        void DeleteMovie(int movieId);
        void AddMovie(Movie movie);
        void EditMovie(Movie movie);
    }
}
