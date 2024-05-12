using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace RealEstate_Dapper_Api.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenResponseViewModel GenerateToken(GetCheckAppUserViewModel request)
        {
            var claims = new List<Claim>();

            if (!string.IsNullOrWhiteSpace(request.Role))
            {
                claims.Add(new Claim(ClaimTypes.Role,request.Role));
            }

            claims.Add(new Claim(ClaimTypes.NameIdentifier, request.Id.ToString()));

            if (!string.IsNullOrWhiteSpace(request.Username))
            {
                claims.Add(new Claim("Username", request.Username));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
            var signInCredentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);
            JwtSecurityToken token = new JwtSecurityToken(issuer:JwtTokenDefaults.ValidIssuer,
                audience:JwtTokenDefaults.ValidAudience,claims:claims,
                notBefore:DateTime.UtcNow,expires:expireDate,signingCredentials:signInCredentials);
            JwtSecurityTokenHandler tokenHandler= new JwtSecurityTokenHandler();
            return new TokenResponseViewModel(tokenHandler.WriteToken(token),expireDate);
        }
    }
}
