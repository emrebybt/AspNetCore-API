using AspNetCore_API_Entity.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AspNetCore_API_Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(IList<string> roles)
        {
            var JwtDefaults = _configuration.GetSection("JwtDefaults");
            var secretKey = JwtDefaults["secretKey"];

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>();
            foreach (var item in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item));
            }

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: JwtDefaults["ValidIssur"],
                audience: JwtDefaults["ValidAudience"],
                claims: claims, 
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(JwtDefaults["expires"])),
                signingCredentials: signingCredentials
                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);
        }
    }
}
