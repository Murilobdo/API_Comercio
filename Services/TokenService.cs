using System.Security.Claims;
using System;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using API_MongoDB.Domain.Company.Models;
using Microsoft.IdentityModel.Tokens;

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
                    new Claim(ClaimTypes.Name, company.NameCompany),
                    new Claim(ClaimTypes.Role, company.Role)
                })
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}