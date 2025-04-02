using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TaskManagement.Modal;

namespace TaskManagement.Manager.CommonMethods
{
    public class JwtServices : IJwt
    {
        private readonly IConfiguration _config;

        public JwtServices(IConfiguration config)
        { 
            _config = config;
        }


        public  string GenerateTokenAsync(EmployeeDto userInfo)
        {
            if (userInfo == null)
                throw new ArgumentNullException(nameof(userInfo), "User information must not be null.");


            var key = _config["Jwt:Key"];
            if (string.IsNullOrEmpty(key))
                throw new InvalidOperationException("JWT Key is not configured.");

            var issuer = _config["Jwt:Issuer"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)) ?? throw new ApplicationException("JWT key is not configured.");
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            // Ensure the properties of userInfo are not null

            var userId = userInfo.EmpId.ToString();
            var EmpName = userInfo.EmpName ?? string.Empty;
            var Roles = userInfo.Roles.ToString();
            var Email = userInfo.Email ?? string.Empty;
            var ManagerId = userInfo.ManagerId.ToString();
            var IsActive = userInfo.IsActive.ToString();
            var expiration = DateTime.UtcNow.AddMinutes(45);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                   new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // Unique identifier
                   new Claim(ClaimTypes.NameIdentifier, userId), // User identifier
                   new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(),         ClaimValueTypes.Integer64), // Issued at
                   new Claim("userid", userId), // Custom claims
                   new Claim("FirstName", EmpName),
                   new Claim("Email", Email),
                }),
                Expires = expiration,
                Issuer = issuer, // Issuer
                SigningCredentials = credentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        
    }
}
