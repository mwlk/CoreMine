using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CoreMine.ApplicationBusiness.Services
{
    public class TokenService
    {
        private readonly string _secretKey = "a_secrect_key_for_create_token_for_dev";

        public string GenerateToken(string username)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim("role", "Admin"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    issuer: "CoreMine.Api",
                    audience: "CoreMine.Client",
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
