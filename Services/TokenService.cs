using System.Security.Claims;
using System;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using API_MongoDB.Domain.Company.Models;
using Microsoft.IdentityModel.Tokens;
using System.Linq;

namespace API_MongoDB.Services
{
    public static class TokenService
    {
        public static string GenerateToken(CompanyEntity company)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("IdCompany", company.Id.ToString()),
                    new Claim(ClaimTypes.Name, company.NameCompany),
                    new Claim(ClaimTypes.Role, company.Role)
                })
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static Guid GetCompanyId(string token)
        {
            token = token.Split(" ")[1];
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.SecretKey);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            Guid idCompany;
            Guid.TryParse(jwtToken.Claims.First(x => x.Type == "IdCompany").Value, out idCompany);
            return idCompany;
        }
    }
}