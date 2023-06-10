using System;
using Microsoft.Extensions.DependencyInjection;
using ScienceArchive.BusinessLogic.ArticleUseCases;
using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.BusinessLogic.NewsUseCases;
using ScienceArchive.BusinessLogic.RoleUseCases;
using ScienceArchive.BusinessLogic.Services;
using ScienceArchive.BusinessLogic.UseCases.Auth;
using ScienceArchive.BusinessLogic.UseCases.System;
using ScienceArchive.BusinessLogic.UserUseCases;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Domain.ValueObjects;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services;
using ScienceArchive.Core.Services.ArticleContracts;
using ScienceArchive.Core.Services.AuthContracts;
using ScienceArchive.Core.Services.NewsContracts;
using ScienceArchive.Core.Services.RoleContracts;
using ScienceArchive.Core.Services.SystemContracts;
using ScienceArchive.Core.Services.UserContracts;

namespace ScienceArchive.BusinessLogic
{
    public static class BusinessLogicRegistry
    {
        /// <summary>
        /// Register domain business logic services
        /// </summary>
        /// <param name="services">System services</param>
        /// <returns>System services with registered business logic services</returns>
        public static IServiceCollection RegisterDomainServices(this IServiceCollection services)
        {
            _ = services.AddSingleton<IArticleService, ArticleService>();
            _ = services.AddSingleton<IAuthService, AuthService>();
            _ = services.AddSingleton<INewsService, NewsService>();
            _ = services.AddSingleton<IRoleService, RoleService>();
            _ = services.AddSingleton<ISystemService, SystemService>();
            _ = services.AddSingleton<IUserService, UserService>();

            return services;
        }

        /// <summary>
        /// Register domain business logic use cases
        /// </summary>
        /// <param name="services">System services</param>
        /// <returns>System services with registered business logic use cases</returns>
        public static IServiceCollection RegisterDomainUseCases(this IServiceCollection services)
        {
            // Artilce use cases
            _ = services.AddTransient<IUseCase<List<Article>, GetAllArticlesContract>, GetAllArticlesUseCase>();
            _ = services.AddTransient<IUseCase<Article, CreateArticleContract>, CreateArticleUseCase>();
            _ = services.AddTransient<IUseCase<Article, UpdateArticleContract>, UpdateArticleUseCase>();
            _ = services.AddTransient<IUseCase<Guid, DeleteArticleContract>, DeleteArticleUseCase>();

            // Auth use cases
            _ = services.AddTransient<IUseCase<User, LoginContract>, LoginUseCase>();

            // News use cases
            _ = services.AddTransient<IUseCase<List<News>, GetAllNewsContract>, GetAllNewsUseCase>();
            _ = services.AddTransient<IUseCase<News, CreateNewsContract>, CreateNewsUseCase>();
            _ = services.AddTransient<IUseCase<News, UpdateNewsContract>, UpdateNewsUseCase>();
            _ = services.AddTransient<IUseCase<Guid, DeleteNewsContract>, DeleteNewsUseCase>();

            // Role use cases
            _ = services.AddTransient<IUseCase<List<Role>, GetAllRolesContract>, GetAllRolesUseCase>();
            _ = services.AddTransient<IUseCase<Role, CreateRoleContract>, CreateRoleUseCase>();
            _ = services.AddTransient<IUseCase<Role, UpdateRoleContract>, UpdateRoleUseCase>();
            _ = services.AddTransient<IUseCase<Guid, DeleteRoleContract>, DeleteRoleUseCase>();

            // System use cases
            _ = services.AddTransient<IUseCase<SystemStatus, CheckSystemStatusContract>, CheckSystemStatusUseCase>();

            // User use cases
            _ = services.AddTransient<IUseCase<List<User>, GetAllUsersContract>, GetAllUsersUseCase>();
            _ = services.AddTransient<IUseCase<User, CreateUserContract>, CreateUserUseCase>();
            _ = services.AddTransient<IUseCase<User, UpdateUserContract>, UpdateUserUseCase>();
            _ = services.AddTransient<IUseCase<Guid, DeleteUserContract>, DeleteUserUseCase>();

            return services;
        }
    }
}

