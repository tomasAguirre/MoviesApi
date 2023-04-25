using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MoviesApi.Areas.Models;
using MoviesApi.Areas.Models.DTO;
using MoviesApi.Areas.ServiceInterfaces;
using MoviesApi.Domains;

namespace MoviesApi.Code.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private ApiContext apiContext;

        public MovieRepository(ApiContext apiContext)
        {
            this.apiContext = apiContext;
        }

        public async Task<bool> createMovie(Movie movie)
        {
            try
            {
                this.apiContext.Movies.Add(movie);
                await this.apiContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }

        public async Task<bool> deleteMovie(int Idmovie)
        {
            try
            {
                var movie = await this.apiContext.Movies.SingleAsync(i => i.Id == Idmovie);
                this.apiContext.Movies.Remove(movie);
                await this.apiContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }

        public IEnumerable<Movie> findAll()
        {
            return  this.apiContext.Movies.ToList();
        }

        public IEnumerable<Movie> findByFilter(DTOSearchMovie dTOSearchMovie)
        {
            var movies = from m in apiContext.Movies.ToList()
                         where (dTOSearchMovie.MovieName == m.Name || dTOSearchMovie.MovieName == null)
                               && (dTOSearchMovie.sypnosis == m.Sypnosis || dTOSearchMovie.sypnosis == null)
                               && (dTOSearchMovie.Category == m.Category || dTOSearchMovie.Category == null)
                               && (dTOSearchMovie.YearOfRealese == m.RelaseYear || dTOSearchMovie.YearOfRealese == null)
                         orderby m.RelaseYear, m.Name, m.CreatedDate
                         select m;
            return movies;
        }

        public Movie findById(int Id)
        {
            return this.apiContext.Movies.SingleOrDefault(x => x.Id == Id);
        }

        public async Task<bool> updateMovie(Movie movie)
        {
            try
            {
                this.apiContext.Movies.Add(movie);
                await this.apiContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }
    }
}
