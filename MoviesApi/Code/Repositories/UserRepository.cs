using Microsoft.EntityFrameworkCore;
using MoviesApi.Areas.Models;
using MoviesApi.Areas.ServiceInterfaces;
using MoviesApi.Domains;

namespace MoviesApi.Code.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApiContext ApiContext;
        public UserRepository(ApiContext ApiContext) 
        {
            this.ApiContext = ApiContext;
        }

        public async Task<bool> deleteUser(int IdUser)
        {
            try
            {
                var user = await this.ApiContext.Users.SingleAsync(i => i.Id == IdUser);
                this.ApiContext.Users.Remove(user);
                await this.ApiContext.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw e;
            }
            return true;
        }

        public IEnumerable<User> findAll()
        {
            return this.ApiContext.Users.ToList();
        }

        public User findById(int Id)
        {
            return this.ApiContext.Users.SingleOrDefault(u => u.Id == Id);
        }

        public  User findByIdEmailPassword(string email, string password)
        {
            var user =  this.ApiContext.Users.FirstOrDefault(i => i.email == email && i.password == password);
            return user;
        }

        public async Task<bool> saveUser(User user)
        {
            try
            {
                this.ApiContext.Users.Add(user);
                await this.ApiContext.SaveChangesAsync();   
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }

        public async Task<bool> updateUser(User user)
        {
            try
            {
                this.ApiContext.Users.Add(user);
                await this.ApiContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }
    }
}
