using LOG_IOT_Service.Models_DbContext;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LOG_IOT_Service.Services
{
    public class TokenService
    {
        public static string GenerateToken(USER _User)
        {
            var TokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, _User.USERNAME),
                    new Claim(ClaimTypes.Role, _User.ROLE),
                    new Claim("USER_ID", _User.USER_ID.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var Token = TokenHandler.CreateToken(tokenDescriptor);
            
            return TokenHandler.WriteToken(Token);
        }
    }
}
