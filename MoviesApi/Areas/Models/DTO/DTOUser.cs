namespace MoviesApi.Areas.Models.DTO
{
    public class DTOUser : AbstractUser
    {
        public override string Name { get; set; }
        public override string email { get; set;  }
        public override string password { get; set;  }
        public override Rol Rol { get; set;  }

        public override string GetUserDetails()
        {
            throw new NotImplementedException();
        }
    }
}
