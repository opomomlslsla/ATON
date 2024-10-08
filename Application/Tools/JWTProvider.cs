using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Tools
{
    public class JWTProvider(IOptions<JwtOptions> options) : IJWTProvider
    {
        JwtOptions _options = options.Value;
        public string GenerateToken(User user)
        {
            List<Claim> claims = new List<Claim>() 
            { 
                new Claim(ClaimTypes.Name, user.Name), 
                new Claim(ClaimTypes.Role, user.IsAdmin ? "admin" : "user")
            };

            var Credentials = new SigningCredentials(key: new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: Credentials,
                expires: DateTime.UtcNow.AddHours(_options.ExpiresIn));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
