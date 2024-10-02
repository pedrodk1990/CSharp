

using Microsoft.IdentityModel.Tokens;
using OAuth2._0.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web.Http;

namespace OAuth2._0.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        private static List<User> users = new List<User>
        {
            new User { Username = "user1", Password = "password1" },
            new User { Username = "user2", Password = "password2" }
        };

        private const string SecretKey = "8Gz!xH@5jLp#1qR2wF$s8yTz9T()JKjh$#@"; // Substitua por uma chave secreta forte

        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login([FromBody] User loginUser)
        {
            var user = users.Find(u => u.Username == loginUser.Username && u.Password == loginUser.Password);
            if (user == null)
                return Unauthorized();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, user.Username) }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new { Token = tokenHandler.WriteToken(token) });
        }

    }
}
