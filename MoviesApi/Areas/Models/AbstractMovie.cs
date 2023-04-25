using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Areas.Models
{
    public enum Category
    {
        scienceFiction,
        comedy,
        Romance,
        Horror
    }

    public abstract class AbstractMovie
    {
        public string Name { get; set; }
        public DateTime RelaseYear { get; set; }
        public string Sypnosis { get; set; }
        public byte[]? Image { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Category? Category { get; set;}
        public abstract string getMovieDetails();
    }
}
