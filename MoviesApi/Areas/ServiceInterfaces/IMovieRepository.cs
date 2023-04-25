using MoviesApi.Areas.Models;
using MoviesApi.Areas.Models.DTO;

namespace MoviesApi.Areas.ServiceInterfaces
{
    public interface IMovieRepository
    {
        public Task<Boolean> createMovie(Movie movie);
        public Task<Boolean> updateMovie(Movie movie);    
        public Task<Boolean> deleteMovie(int Idmovie);    
        public IEnumerable<Movie>  findAll();
        public Movie findById(int Id);
        public IEnumerable<Movie> findByFilter(DTOSearchMovie dTOSearchMovie);
    }
}
