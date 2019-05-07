using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MoviesTestAPI.Interfaces;
using MoviesTestAPI.Models;

namespace MoviesTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet]
        [Route("GetMovies")]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult<List<Movie>>> GetMovies()
        {
            return await _movieRepository.GetMovies();
        }

        [HttpGet]
        [Route("GetMovieStats")]
        [EnableCors("CorsPolicy")]
        public ActionResult<List<MovieStats>> GetMovieStats()
        {
            return _movieRepository.GetMovieStats();
        }

        [HttpDelete]
        [Route("DeleteMovie/{movieId}")]
        [EnableCors("CorsPolicy")]
        public void DeleteMovie([FromRoute]int movieId)
        {
            _movieRepository.DeleteMovie(movieId);
        }
        
        [HttpPost]
        [Route("AddMovie")]
        [EnableCors("CorsPolicy")]
        public void AddMovie([FromBody] Movie movie)
        {
            _movieRepository.AddMovie(movie);
        }

        [HttpPut]
        [Route("EditMovie")]
        [EnableCors("CorsPolicy")]
        public void EditMovie([FromBody] Movie movie)
        {
            _movieRepository.EditMovie(movie);
        }
    }
}
