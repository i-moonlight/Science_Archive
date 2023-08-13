using Microsoft.Extensions.DependencyInjection;
using ScienceArchive.Application.Dtos;
using ScienceArchive.Application.Dtos.Article;
using ScienceArchive.Application.Dtos.Claim;
using ScienceArchive.Application.Dtos.News;
using ScienceArchive.Application.Dtos.Role;
using ScienceArchive.Application.Interactors;
using ScienceArchive.Application.Interfaces;
using ScienceArchive.Application.Interfaces.Interactors;
using ScienceArchive.Application.Mappers;
using ScienceArchive.Core.Domain.Aggregates.Article;
using ScienceArchive.Core.Domain.Aggregates.News;
using ScienceArchive.Core.Domain.Aggregates.Role;
using ScienceArchive.Core.Domain.Aggregates.Role.ValueObjects;
using ScienceArchive.Core.Domain.Aggregates.User;

namespace ScienceArchive.Application;

public static class ApplicationRegistry
{
    /// <summary>
    /// Register application layer interactors
    /// </summary>
    /// <param name="services">System services</param>
    /// <returns>System services with registered interactors</returns>
    public static IServiceCollection RegisterInteractors(this IServiceCollection services)
    {
        _ = services.AddSingleton<IArticleInteractor, ArticleInteractor>();
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
    public static IServiceCollection RegisterApplicationMappers(this IServiceCollection services)
    {
        _ = services.AddTransient<IApplicationMapper<Article, ArticleDto>, ArticleMapper>();
        _ = services.AddTransient<IApplicationMapper<RoleClaim, ClaimDto>, ClaimMapper>();
        _ = services.AddTransient<IApplicationMapper<News, NewsDto>, NewsMapper>();
        _ = services.AddTransient<IApplicationMapper<Role, RoleDto>, RoleMapper>();
        _ = services.AddTransient<IApplicationMapper<User, UserDto>, UserMapper>();

        return services;
    }
}