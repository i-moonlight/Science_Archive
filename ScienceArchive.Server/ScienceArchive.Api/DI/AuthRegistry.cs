using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AuthRegistry
    {
        public static IServiceCollection RegisterAuth(this IServiceCollection services, ConfigurationManager configuration)
        {
            var jwtKey = configuration["Jwt:Key"] ?? "";
            var jwtAudience = configuration["Jwt:Audience"] ?? "";
            var jwtIssuer = configuration["Jwt:Issuer"] ?? "";

            _ = services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
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

            return services;
        }
    }
}

