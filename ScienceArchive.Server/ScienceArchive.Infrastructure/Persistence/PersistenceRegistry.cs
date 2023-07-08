using Microsoft.Extensions.DependencyInjection;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Infrastructure.Persistence.Interfaces;
using ScienceArchive.Infrastructure.Persistence.Options;
using ScienceArchive.Infrastructure.Persistence.PostgreSql;
using ScienceArchive.Infrastructure.Persistence.PostgreSql.Mappers;
using ScienceArchive.Infrastructure.Persistence.PostgreSql.Models;
using ScienceArchive.Infrastructure.Persistence.PostgreSql.Repositories;

namespace ScienceArchive.Infrastructure.Persistence;

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

    public static IServiceCollection RegisterPersistenceMappers(this IServiceCollection services)
    {
        _ = services.AddTransient<IPersistenceMapper<Article, ArticleModel>, ArticleMapper>();
        _ = services.AddTransient<IPersistenceMapper<Claim, ClaimModel>, ClaimMapper>();
        _ = services.AddTransient<IPersistenceMapper<News, NewsModel>, NewsMapper>();
        _ = services.AddTransient<IPersistenceMapper<Role, RoleModel>, RoleMapper>();
        _ = services.AddTransient<IPersistenceMapper<User, UserModel>, UserMapper>();

        return services;
    }

    /// <summary>
    /// Register database context
    /// </summary>
    /// <param name="services">Application services</param>
    /// <param name="connectionOptions">Database connection options</param>
    public static IServiceCollection RegisterPersistenceConnections(this IServiceCollection services, ConnectionOptions connectionOptions)
    {
        if (connectionOptions.PostgresConnectionString is null)
        {
            throw new ArgumentNullException(nameof(connectionOptions));
        }

        var postgresContext = new PostgresContext(connectionOptions.PostgresConnectionString);

        _ = services.AddSingleton(postgresContext);

        return services;
    }
}