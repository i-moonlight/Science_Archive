using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Interfaces.Mappers;
using ScienceArchive.Core.Interfaces.Repositories;
using ScienceArchive.Infrastructure.Persistence.Mappers;
using ScienceArchive.Infrastructure.Persistence.Models;
using ScienceArchive.Infrastructure.Persistence.PostgreSql.Repositories;
using ScienceArchive.Infrastructure.Persistence.Repositories;

namespace ScienceArchive.Infrastructure.Persistence
{
    public static class PersistenceRegistry
    {
        /// <summary>
        /// Register repositories implementations
        /// </summary>
        /// <param name="services">Application services</param>
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            _ = services.AddTransient<IArticleRepository, PostgresArticleRepository>();
            _ = services.AddTransient<INewsRepository, PostgresNewsRepository>();
            _ = services.AddTransient<IRoleRepository, PostgresRoleRepository>();
            _ = services.AddTransient<IUserRepository, PostgresUserRepository>();

            return services;
        }

        public static IServiceCollection RegisterPersistenceLayerMappers(this IServiceCollection services)
        {
            _ = services.AddTransient<IMapper<User, UserModel>, UserMapper>();

            return services;
        }

        /// <summary>
        /// Register database context
        /// </summary>
        /// <param name="services">Application services</param>
        /// <param name="connectionString">Database connection string</param>
        public static IServiceCollection RegisterDbContext(this IServiceCollection services, string connectionString)
        {
            _ = services.AddDbContext<ScienceArchiveDbContext>(options =>
                options.UseNpgsql(connectionString)
            );

            return services;
        }
    }
}

