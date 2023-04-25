using Microsoft.AspNetCore.Mvc;
using MoviesApi.Areas.Models.DTO;
using MoviesApi.Areas.Models;
using MoviesApi.Areas.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;

namespace MoviesApi.Areas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RatingController : Controller
    {
        private IRatingRepository _ratingRepository;
        private IUserRepository _userRepository;
        private IMovieRepository _movieRepository;  
        public RatingController(IRatingRepository ratingRepository, IUserRepository userRepository, IMovieRepository movieRepository)
        {
            this._ratingRepository = ratingRepository;
            this._userRepository = userRepository;
            this._movieRepository = movieRepository;
        }

        [NonAction]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> saveRating(DTORating dtoRating)
        {
            Rating rating = new Rating();
            User user = this._userRepository.findById(dtoRating.idUser);
            Movie movie = this._movieRepository.findById(dtoRating.idMovie);
            rating.movie = movie;
            rating.user = user;
            await this._ratingRepository.createRating(rating);
            return Ok();
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<Rating> getAllRatings()
        {
            IEnumerable<Rating> objCatlist = this._ratingRepository.getRatingList();

            return objCatlist;
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> deleteRating(int id)
        {
            this._ratingRepository.deleteRating(id);

            return Ok();
        }
    }
}
