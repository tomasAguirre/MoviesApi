using MoviesApi.Areas.Models.DTO;
using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Areas.Models
{
    public class Movie : AbstractMovie
    {
        public Movie()
        {
        }

        public Movie(DTOMovie dTOMovie)
        {
            this.Name = dTOMovie.Name;
            this.RelaseYear = dTOMovie.RelaseYear;
            this.Sypnosis = dTOMovie.Sypnosis;
            this.CreatedBy = dTOMovie.CreatedBy;
            this.CreatedDate = dTOMovie.CreatedDate;
            this.Category = dTOMovie.Category;
            this.Image = dTOMovie.Image;
        }



        [Key]
        public int Id { get; set; }
        public ICollection<Rating> Ratings { get; set; }

        public override string getMovieDetails()
        {
            return $"Id: {Id}, Name: {Name}, RelaseYear : {RelaseYear}, Sypnosis : {Sypnosis}, " +
               $"CreatedBy : {CreatedBy}, CreatedDate : {CreatedDate}, Category : {Category}, Image : {Image}";
        }
    }
}
