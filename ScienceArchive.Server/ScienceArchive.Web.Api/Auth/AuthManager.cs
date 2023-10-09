using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ScienceArchive.Application.Dtos;

using JwtClaim = System.Security.Claims.Claim;

namespace ScienceArchive.Web.Api.Auth;

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
        string jwtKey;
        var jwtSub = _configuration["Jwt:Sub"] ?? "";
        var jwtAudience = _configuration["Jwt:Audience"] ?? "";
        var jwtIssuer = _configuration["Jwt:Issuer"] ?? "";

        if (_hostEnvironment.IsDevelopment())
        {
            jwtKey = _configuration["Jwt:Key"] ?? "";
        }
        else
        {
            jwtKey = Environment.GetEnvironmentVariable("SCIENCE_ARCHIVE_JWT_KEY") ?? throw new NullReferenceException("JWT key was not present!");
        }

        if (user.Id is null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        var claims = new[]
        {
            new JwtClaim(JwtRegisteredClaimNames.Sub, jwtSub),
            new JwtClaim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new JwtClaim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)),
            new JwtClaim("UserId", user.Id)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        
        var token = new JwtSecurityToken(
            jwtIssuer,
            jwtAudience,
            claims,
            expires: DateTime.UtcNow.AddDays(7),
            signingCredentials: signIn);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}