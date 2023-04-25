using MoviesApi.Areas.Models.DTO;
using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Areas.Models
{
    public class User : AbstractUser
    {
        public User()
        {
        }

        public User(DTOUser dtoUser)
        {
            Name = dtoUser.Name;
            this.email = dtoUser.email;
            this.password = dtoUser.password;
            Rol = dtoUser.Rol;
        }

        [Key]
        public int Id { get; set; }
        public override string Name { get; set; }
        public override string email { get; set; }
        public override string password { get; set; }
        public override Rol Rol { get; set; }

        public ICollection<Rating> Ratings { get; set; }
        public override string GetUserDetails()
        {
            return $"Id: {Id}, Name: {Name}, email : {email}, rol : {Rol}";
        }
    }
}
