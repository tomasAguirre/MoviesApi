using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace MoviesApi.Areas.Models
{
    public class Rating : AbstractRating
    {
        public Rating()
        {
        }

        public Rating(Rate rate, Movie movie, User user)
        {
            this.rate = rate;
            this.movie = movie;
            this.user = user;
        }

        [Key]
        public int Id { get; set; }
        public int idMovie { get; set; }
        public virtual Movie movie { get; set; }

        public int idUser { get; set; }
        public virtual User user { get; set; }

    }
}
