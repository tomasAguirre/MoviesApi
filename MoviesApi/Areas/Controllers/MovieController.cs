using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Areas.Models;
using MoviesApi.Areas.Models.DTO;
using MoviesApi.Areas.ServiceInterfaces;

namespace MoviesApi.Areas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : Controller
    {
        private IMovieRepository movieRepository;
        public MovieController(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> saveMovie(DTOMovie dtoMovie)
        {
            Movie movie = new Movie(dtoMovie);
            await this.movieRepository.createMovie(movie);
            return Ok();
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> deleteMovies(int id)
        {
            this.movieRepository.deleteMovie(id);

            return Ok();
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> deleteMovies(Movie movie)
        {
            this.movieRepository.updateMovie(movie);

            return Ok();
        }

        [HttpGet]
        [Route("findMovie")]
        public IEnumerable<Movie> findMovie(DTOSearchMovie dTOSearchMovie)
        {
            var movies = this.movieRepository.findByFilter(dTOSearchMovie);
            return movies;
        }

        [NonAction]
        public IActionResult Index()
        {
            return View();
        }
    }
}
