using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace ScienceArchive.Web.Api.Auth;

public static class AuthRegistry
{
    public static IServiceCollection RegisterAuth(this IServiceCollection services, ConfigurationManager configuration, bool isDevelopment)
    {
        var jwtAudience = configuration["Jwt:Audience"] ?? "";
        var jwtIssuer = configuration["Jwt:Issuer"] ?? "";

        string jwtKey;

        if (isDevelopment)
        {
            jwtKey = configuration["Jwt:Key"] ?? "";
        }
        else
        {
            jwtKey = Environment.GetEnvironmentVariable("SCIENCE_ARCHIVE_JWT_KEY")
                     ?? throw new NullReferenceException("JWT key was not present!");
        }

        _ = services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = jwtAudience,
                    ValidIssuer = jwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                };
            });

        _ = services.AddTransient<AuthManager>();

        return services;
    }
}