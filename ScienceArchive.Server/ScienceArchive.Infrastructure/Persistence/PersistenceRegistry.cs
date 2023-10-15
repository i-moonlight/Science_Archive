using ClickHouse.Client;
using ClickHouse.Client.ADO;
using Dapper;
using Microsoft.Extensions.DependencyInjection;
using ScienceArchive.Core.Domain.Aggregates.Article;
using ScienceArchive.Core.Domain.Aggregates.Category;
using ScienceArchive.Core.Domain.Aggregates.News;
using ScienceArchive.Core.Domain.Aggregates.Role;
using ScienceArchive.Core.Domain.Aggregates.Role.ValueObjects;
using ScienceArchive.Core.Domain.Aggregates.User;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Infrastructure.Persistence.ClickHouse.Repositories;
using ScienceArchive.Infrastructure.Persistence.Interfaces;
using ScienceArchive.Infrastructure.Persistence.Options;
using ScienceArchive.Infrastructure.Persistence.PostgreSql;
using ScienceArchive.Infrastructure.Persistence.PostgreSql.Models;
using ScienceArchive.Infrastructure.Persistence.PostgreSql.Repositories;
using ScienceArchive.Infrastructure.PostgreSql.PersistenceMappers;
using ScienceArchive.Infrastructure.PostgreSql.SqlMappers;

namespace ScienceArchive.Infrastructure.Persistence;

public static class PersistenceRegistry
{
    /// <summary>
    /// Register all required persistence services
    /// </summary>
    /// <param name="services">Instance of <see cref="IServiceCollection"/></param>
    public static IServiceCollection RegisterPersistenceLayer(this IServiceCollection services, ConnectionOptions connectionOptions)
    {
        _ = RegisterRepositories(services);
        _ = RegisterPersistenceMappers(services);
        _ = RegisterPersistenceConnections(services, connectionOptions);

        return services;
    }
    
    /// <summary>
    /// Register repositories implementations
    /// </summary>
    /// <param name="services">Application services</param>
    private static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        _ = services.AddTransient<IArticleRepository, PostgresArticleRepository>();
        _ = services.AddTransient<ICategoryRepository, PostgresCategoryRepository>();
        _ = services.AddTransient<INewsRepository, PostgresNewsRepository>();
        _ = services.AddTransient<IRoleRepository, PostgresRoleRepository>();
        _ = services.AddTransient<IUserRepository, PostgresUserRepository>();
        _ = services.AddTransient<ILogRepository, ClickHouseLogRepository>();

        return services;
    }

    private static IServiceCollection RegisterPersistenceMappers(this IServiceCollection services)
    {
        // Register mappers from entities to models and vice versa
        _ = services.AddTransient<IPersistenceMapper<Article, ArticleModel>, ArticleMapper>();
        _ = services.AddTransient<IPersistenceMapper<Category, CategoryModel>, CategoryMapper>();
        _ = services.AddTransient<IPersistenceMapper<RoleClaim, ClaimModel>, ClaimMapper>();
        _ = services.AddTransient<IPersistenceMapper<Category, SubcategoryModel>, SubcategoryMapper>();
        _ = services.AddTransient<IPersistenceMapper<News, NewsModel>, NewsMapper>();
        _ = services.AddTransient<IPersistenceMapper<Role, RoleModel>, RoleMapper>();
        _ = services.AddTransient<IPersistenceMapper<User, UserModel>, UserMapper>();
        _ = services.AddTransient<IPersistenceMapper<Author, AuthorModel>, AuthorMapper>();
        
        // Register mappers from SQL tables to models
        SqlMapper.AddTypeHandler(new GenericArrayToListMapper<Guid>());
        SqlMapper.AddTypeHandler(new GenericJsonMapper<List<ArticleDocumentModel>>());
        SqlMapper.AddTypeHandler(new GenericJsonMapper<List<SubcategoryModel>>());

        return services;
    }

    /// <summary>
    /// Register database context
    /// </summary>
    /// <param name="services">Application services</param>
    /// <param name="connectionOptions">Database connection options</param>
    private static IServiceCollection RegisterPersistenceConnections(this IServiceCollection services, ConnectionOptions connectionOptions)
    {
        RegisterPostgreSql(services, connectionOptions.PostgresConnectionString);
        RegisterClickHouse(services, connectionOptions.ClickHouseConnectionString);
        
        return services;
    }

    /// <summary>
    /// Register connection to PostgreSQL
    /// </summary>
    /// <param name="services"></param>
    /// <param name="connectionString"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    private static IServiceCollection RegisterPostgreSql(this IServiceCollection services, string? connectionString)
    {
        if (connectionString is null)
        {
            throw new ArgumentNullException(nameof(connectionString));
        }

        var postgresContext = new PostgresContext(connectionString);

        _ = services.AddSingleton(postgresContext);

        return services;
    }

    /// <summary>
    /// Register connection to ClickHouse
    /// </summary>
    /// <param name="services"></param>
    /// <param name="connectionString"></param>
    /// <returns></returns>
    private static IServiceCollection RegisterClickHouse(this IServiceCollection services, string connectionString)
    {
        var connection = new ClickHouseConnection(connectionString);
        
        _ = services.AddSingleton<IClickHouseConnection>(connection);
        
        return services;
    }
}