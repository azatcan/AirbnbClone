using Airbnb.Domain.Data;
using AirbnbClone.API.Models;
using JWTExample.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AirbnbClone.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IOptions<JwtOption> _jwtOption;

        public AccountController(DataContext dataContext, IOptions<JwtOption> jwtOption)
        {
            _dataContext = dataContext;
            _jwtOption = jwtOption;
        }

        public IActionResult Login()
        {
            return View(new LoginRequest());
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request,Guid Id)
        {
            var user = _dataContext.Users.FirstOrDefault(u => u.UserName == request.UserName);
            if (user != null)
            {
                string hashedPassword = HashPassword(request.Password);
                if (user.PasswordHash == hashedPassword)
                {
                   HttpContext.Session.SetString("UserName",request.UserName);
                   HttpContext.Session.SetString("token", GenerateJwtToken(request));
                    return RedirectToAction("Index", "Home");                   
                }
            }
            return View();
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
