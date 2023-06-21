using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ScienceArchive.Core.Domain.Entities;

using JwtClaim = System.Security.Claims.Claim;
using ScienceArchive.Application.Dtos;

namespace ScienceArchive.Web.Api.Auth
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

        public string GenerateToken(UserDto user)
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

            if (user.Id is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var claims = new[]
            {
                new JwtClaim(JwtRegisteredClaimNames.Sub, jwtSub),
                new JwtClaim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new JwtClaim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new JwtClaim("UserId", user.Id.ToString()),
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

