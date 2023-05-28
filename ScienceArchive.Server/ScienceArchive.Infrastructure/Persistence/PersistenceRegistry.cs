using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ScienceArchive.Core.Interfaces.Repositories;
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
            _ = services.AddTransient<IArticleRepository, ArticleRepository>();
            _ = services.AddTransient<INewsRepository, NewsRepository>();
            _ = services.AddTransient<IRoleRepository, RoleRepository>();
            _ = services.AddTransient<IUserRepository, UserRepository>();

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

