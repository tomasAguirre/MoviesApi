using MoviesApi.Areas.Models;
using MoviesApi.Areas.Models.DTO;
using MoviesApi.Areas.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingMoviesProject.repos
{
    internal class MovieTestRepository : IMovieRepository
    {
        private readonly List<Movie> _movies;   
        public async Task<bool> createMovie(Movie movie)
        {
            try
            {
                _movies.Add(movie);
            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }

        public async Task<bool> deleteMovie(int Idmovie)
        {
            try
            {
                
            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }

        public IEnumerable<Movie> findAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> findByFilter(DTOSearchMovie dTOSearchMovie)
        {
            throw new NotImplementedException();
        }

        public Task<bool> updateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
