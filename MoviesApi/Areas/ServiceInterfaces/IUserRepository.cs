using MoviesApi.Areas.Models;

namespace MoviesApi.Areas.ServiceInterfaces
{
    public interface IUserRepository
    {
        public Task<Boolean> saveUser(User user);
        public Task<Boolean> updateUser(User user);
        public Task<Boolean> deleteUser(int IdUser);   
        public IEnumerable<User> findAll();
        public User findById(int Id);
        public User findByIdEmailPassword(string email, string password);
    }
}
