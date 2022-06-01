using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Helbiz.Application.Interfaces.Helpers;
using Helbiz.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Helbiz.Application.Helpers
{
    public class JwtHelper : IJwtHelper
    {
        private const string Issuer = "https://github.com";
        private const string Audience = "https://github.com";
        private const string SecretKey = "990A1A5253B54FC69366C228FEE2D722";

        public string GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, $"{user.Firstname} {user.Lastname}"),
                new Claim("UserId", user.Id.ToString())
            };
            var token = new JwtSecurityToken(audience: Audience, issuer: Issuer, claims: claims,
                expires: DateTime.UtcNow.AddDays(1), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}