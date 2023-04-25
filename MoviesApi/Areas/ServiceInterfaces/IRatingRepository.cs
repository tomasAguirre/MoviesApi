using MoviesApi.Areas.Models;

namespace MoviesApi.Areas.ServiceInterfaces
{
    public interface IRatingRepository
    {
        public Task<Boolean> createRating(Rating rating);
        public Task<Boolean> updateRating(Rating rating);
        public Task<Boolean> deleteRating(int  IdRating);
        public IEnumerable<Rating>  getRatingList();

    }
}
