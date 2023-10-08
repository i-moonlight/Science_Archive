using Microsoft.Extensions.DependencyInjection;
using ScienceArchive.Application.Dtos;
using ScienceArchive.Application.Dtos.Article;
using ScienceArchive.Application.Dtos.Category;
using ScienceArchive.Application.Dtos.Claim;
using ScienceArchive.Application.Dtos.News;
using ScienceArchive.Application.Dtos.Role;
using ScienceArchive.Application.Interactors;
using ScienceArchive.Application.Interfaces;
using ScienceArchive.Application.Interfaces.Interactors;
using ScienceArchive.Application.Mappers;
using ScienceArchive.Core.Domain.Aggregates.Article;
using ScienceArchive.Core.Domain.Aggregates.Category;
using ScienceArchive.Core.Domain.Aggregates.News;
using ScienceArchive.Core.Domain.Aggregates.Role;
using ScienceArchive.Core.Domain.Aggregates.Role.ValueObjects;
using ScienceArchive.Core.Domain.Aggregates.User;

namespace ScienceArchive.Application;

public static class ApplicationRegistry
{
    /// <summary>
    /// Register all required application layer services 
    /// </summary>
    /// <param name="services">Instance of <see cref="IServiceCollection"/></param>
    /// <param name="options">Application layer options</param>
    public static IServiceCollection RegisterApplicationLayer(this IServiceCollection services)
    {
        _ = RegisterInteractors(services);
        _ = RegisterApplicationMappers(services);

        return services;
    }
    
    /// <summary>
    /// Register application layer interactors
    /// </summary>
    /// <param name="services">System services</param>
    /// <returns>System services with registered interactors</returns>
    private static IServiceCollection RegisterInteractors(this IServiceCollection services)
    {
        _ = services.AddSingleton<IArticleInteractor, ArticleInteractor>();
        _ = services.AddSingleton<ICategoryInteractor, CategoryInteractor>();
        _ = services.AddSingleton<IAuthInteractor, AuthInteractor>();
        _ = services.AddSingleton<INewsInteractor, NewsInteractor>();
        _ = services.AddSingleton<IRoleInteractor, RoleInteractor>();
        _ = services.AddSingleton<ISystemInteractor, SystemInteractor>();
        _ = services.AddSingleton<IUserInteractor, UserInteractor>();

        return services;
    }

    /// <summary>
    /// Register application layer mappers
    /// </summary>
    /// <param name="services">System services</param>
    /// <returns>System services with registered application layer mappers</returns>
    private static IServiceCollection RegisterApplicationMappers(this IServiceCollection services)
    {
        _ = services.AddTransient<IApplicationMapper<Article, ArticleDto>, ArticleMapper>();
        _ = services.AddTransient<IApplicationMapper<Category, CategoryDto>, CategoryMapper>();
        _ = services.AddTransient<IApplicationMapper<RoleClaim, ClaimDto>, ClaimMapper>();
        _ = services.AddTransient<IApplicationMapper<News, NewsDto>, NewsMapper>();
        _ = services.AddTransient<IApplicationMapper<Role, RoleDto>, RoleMapper>();
        _ = services.AddTransient<IApplicationMapper<User, UserDto>, UserMapper>();
        _ = services.AddTransient<IApplicationMapper<Author, AuthorDto>, AuthorMapper>();

        return services;
    }
}