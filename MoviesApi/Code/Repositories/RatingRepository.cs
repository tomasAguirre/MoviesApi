using Microsoft.EntityFrameworkCore;
using MoviesApi.Areas.Models;
using MoviesApi.Areas.ServiceInterfaces;
using MoviesApi.Domains;

namespace MoviesApi.Code.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private ApiContext apiContext;
        public RatingRepository(ApiContext apiContext)
        {
            this.apiContext = apiContext;
        }

        public async Task<bool> createRating(Rating rating)
        {
            try
            {
                this.apiContext.Ratings.Add(rating);
                await this.apiContext.SaveChangesAsync();   
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }

        public async Task<bool> deleteRating(int IdRating)
        {
            try
            {
                var rating = await this.apiContext.Ratings.SingleAsync(i => i.Id == IdRating);
                this.apiContext.Ratings.Remove(rating);
                await this.apiContext.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw e;
            }
            return true;
        }

        public IEnumerable<Rating> getRatingList()
        {
            return this.apiContext.Ratings.ToList();
        }

        public async Task<bool> updateRating(Rating rating)
        {
            try
            {
                this.apiContext.Ratings.Add(rating);
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
