using Airbnb.Domain.Data;
using Airbnb.Domain.Entities;
using AirbnbClone.API.Models;
using JWTExample.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace JWTExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IOptions<JwtOption> _jwtOption;

        public AuthenticateController(DataContext dataContext, IOptions<JwtOption> jwtOption)
        {
            _dataContext = dataContext;
            _jwtOption = jwtOption;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = _dataContext.Users.FirstOrDefault(u => u.UserName == request.UserName);
            if (user != null)
            {
                string hashedPassword = HashPassword(request.Password);
                if (user.PasswordHash == hashedPassword)
                {
                    var token = GenerateJwtToken(request);
                    return Ok(new LoginResponse { Token = token});
                }

            }
            return BadRequest("Kullanıcı adı veya şifre hatalı");
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistration userRegistration)
        {


            var user = new User
            {
                UserName = userRegistration.UserName,
                Email = userRegistration.Email,
                PasswordHash = HashPassword(userRegistration.Password)
            };

            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();
            return Ok();

        }

        private string GenerateJwtToken(LoginRequest request)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOption.Value.Key.ToString()));

            var tokenDescriptior = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, request.Password.ToString()),
                    new Claim(ClaimTypes.Name, request.UserName!),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256),
                Issuer = _jwtOption.Value.Issuer,
                Audience = _jwtOption.Value.Audience,

            };
            var token = tokenHandler.CreateToken(tokenDescriptior);

            return tokenHandler.WriteToken(token);
        }

        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}
