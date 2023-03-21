using System;
using Microsoft.EntityFrameworkCore;
using ScienceArchive.Core.Interfaces.Repositories;
using ScienceArchive.Infrastructure.Persistence;
using ScienceArchive.Infrastructure.Persistence.Repositories;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Registry of repositories in system
    /// </summary>
    public static class PersistenceRegistry
    {
        /// <summary>
        /// Register repositories implementations
        /// </summary>
        /// <param name="services">Application services</param>
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            _ = services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection RegisterDbContext(this IServiceCollection services, string connectionString)
        {
            _ = services.AddDbContext<ScienceArchiveDbContext>(options =>
                options.UseNpgsql(connectionString)
            );

            return services;
        }
    }
}

