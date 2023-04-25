using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MoviesApi.Areas.Models;
using System;  
using System.Configuration; 
namespace MoviesApi.Domains
{
    public class ApiContext : DbContext
    {

        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Rating> Ratings { get; set; }


    }
}
