using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace MoviesApi.Areas.Models
{
    public enum Rate
    {
        good,
        bad,
        incredible
    }
    public abstract class AbstractRating
    {
        public Rate rate { get; set; }

    }
}
