using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApiPerson.Entities;

namespace WebApiPerson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly string secretKey;

        public AuthenticationController(IConfiguration configuration)
        {
            secretKey = configuration.GetSection("settings").GetSection("secretkey").ToString();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] User user)
        {
            if(user.Username == "example@gmail.com" && user.Password == "123")
            {
                var keyBytes = Encoding.ASCII.GetBytes(secretKey);
                var claims = new ClaimsIdentity();

                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Username));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);
               
                string newToken  = tokenHandler.WriteToken(tokenConfig);
                return StatusCode(StatusCodes.Status200OK, new { token = newToken });

            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { token = ""});
            }

        }
    }
}
