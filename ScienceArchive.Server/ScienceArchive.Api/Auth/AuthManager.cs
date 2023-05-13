using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ScienceArchive.Core.Dtos;
using ScienceArchive.Core.Dtos.User;
using ScienceArchive.Core.Entities;

namespace ScienceArchive.Api.Auth
{
    public class AuthManager
    {
        private readonly IConfiguration _configuration;
        private readonly IHostEnvironment _hostEnvironment;

        public AuthManager(IConfiguration configuration, IHostEnvironment hostEnvironment)
        {
            _configuration = configuration;
            _hostEnvironment = hostEnvironment;
        }

        public string GenerateToken(IdentifiedUserDto user)
        {
            var jwtSub = _configuration["Jwt:Sub"] ?? "";
            var jwtAudience = _configuration["Jwt:Audience"] ?? "";
            var jwtIssuer = _configuration["Jwt:Issuer"] ?? "";
            string jwtKey;

            if (_hostEnvironment.IsDevelopment())
            {
                jwtKey = _configuration["Jwt:Key"] ?? "";
            }
            else
            {
                jwtKey = Environment.GetEnvironmentVariable("SCIENCE_ARCHIVE_JWT_KEY")
                    ?? throw new NullReferenceException("JWT key was not present!");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, jwtSub),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("UserId", user.Id.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                jwtIssuer,
                jwtAudience,
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

