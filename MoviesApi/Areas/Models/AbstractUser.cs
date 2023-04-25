using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Areas.Models
{
    public enum Rol
    {
        admin,
        user,
    }
    public abstract class AbstractUser
    {
        public abstract string Name { get; set; }
        public abstract string email { get; set; }
        public abstract string password { get; set; }
        public abstract Rol Rol { get; set; }
        public abstract string GetUserDetails();
    }
}
