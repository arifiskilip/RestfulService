using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace WebUI.Auth
{
    public static class TokenGenerator
    {
        public static string GenerateToken()
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysecretkey123."));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken tokent = new JwtSecurityToken(issuer:"https://localhost",audience: "https://localhost",notBefore:DateTime.Now,expires:DateTime.Now.AddMinutes(10),signingCredentials:credentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(tokent);
         }
    }
}
