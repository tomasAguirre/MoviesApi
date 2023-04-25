using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MoviesApi.Areas.Models;
using MoviesApi.Areas.Models.DTO;
using MoviesApi.Areas.ServiceInterfaces;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MoviesApi.Areas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private IUserRepository userRepository;
        IConfiguration configuration;
        public UserController(IUserRepository userRepository, IConfiguration configuration)
        {
            this.userRepository = userRepository;
            this.configuration = configuration;
        }
        [NonAction]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> createUser(DTOUser dTOUser)
        {
            User user = new User(dTOUser);
           await this.userRepository.saveUser(user);
            return Ok();
        }

        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return this.userRepository.findAll();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public  IActionResult Login(string email, string password, JwtRegisteredClaimNames jwtRegisteredClaimNames)
        {
            IActionResult response = Unauthorized();
            var user =   this.userRepository.findByIdEmailPassword(email,password);
            if(user != null)
            {
                var issuer = configuration["Jwt:Issuer"];
                var audience = configuration["Jwt:Audience"];
                var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
                var signingCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature
                );

                var subject = new ClaimsIdentity(new[]
{
                        new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                        new Claim(JwtRegisteredClaimNames.Email, user.email),
                 });


                var expires = DateTime.UtcNow.AddMinutes(10);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = subject,
                    Expires = expires,
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = signingCredentials
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);

                return Ok(jwtToken);

            }
            return response;
        }


    }
}
