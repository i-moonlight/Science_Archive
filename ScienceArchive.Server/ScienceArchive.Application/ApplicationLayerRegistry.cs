using System;
using Microsoft.Extensions.DependencyInjection;
using ScienceArchive.Application.Mappers;
using ScienceArchive.Application.Services;
using ScienceArchive.Application.UseCases;
using ScienceArchive.Application.UseCases.Article;
using ScienceArchive.Application.UseCases.Auth;
using ScienceArchive.Application.UseCases.News;
using ScienceArchive.Application.UseCases.Role;
using ScienceArchive.Application.UseCases.System;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Dtos;
using ScienceArchive.Core.Dtos.ArticleRequest;
using ScienceArchive.Core.Dtos.ArticleResponse;
using ScienceArchive.Core.Dtos.Auth.Request;
using ScienceArchive.Core.Dtos.Auth.Response;
using ScienceArchive.Core.Dtos.News.Request;
using ScienceArchive.Core.Dtos.News.Response;
using ScienceArchive.Core.Dtos.Role.Request;
using ScienceArchive.Core.Dtos.Role.Response;
using ScienceArchive.Core.Dtos.System.Request;
using ScienceArchive.Core.Dtos.System.Response;
using ScienceArchive.Core.Dtos.User.Request;
using ScienceArchive.Core.Dtos.UserRequest;
using ScienceArchive.Core.Dtos.UserResponse;
using ScienceArchive.Core.Interfaces.Mappers;
using ScienceArchive.Core.Interfaces.Services;
using ScienceArchive.Core.Interfaces.UseCases;

namespace ScienceArchive.Application
{
    public static class ApplicationLayerRegistry
    {
        /// <summary>
        /// Register default services implementations
        /// </summary>
        /// <param name="services">Application services</param>
        /// <returns>Registered services</returns>
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            _ = services.AddTransient<IArticleService, ArticleService>();
            _ = services.AddTransient<IAuthService, AuthService>();
            _ = services.AddTransient<INewsService, NewsService>();
            _ = services.AddTransient<IRoleService, RoleService>();
            _ = services.AddTransient<ISystemService, SystemService>();
            _ = services.AddTransient<IUserService, UserService>();

            return services;
        }

        /// <summary>
        /// Register default Use Cases for services implementations
        /// </summary>
        /// <param name="services">Application services</param>
        /// <returns>Services with registered Use Cases</returns>
        public static IServiceCollection RegisterUseCases(this IServiceCollection services)
        {
            // Article use cases
            _ = services.AddTransient<IUseCase<GetAllArticlesResponseDto, GetAllArticlesRequestDto>, GetAllArticlesUseCase>();
            _ = services.AddTransient<IUseCase<CreateArticleResponseDto, CreateArticleRequestDto>, CreateArticleUseCase>();
            _ = services.AddTransient<IUseCase<UpdateArticleResponseDto, UpdateArticleRequestDto>, UpdateArticleUseCase>();
            _ = services.AddTransient<IUseCase<DeleteArticleResponseDto, DeleteArticleRequestDto>, DeleteArticleUseCase>();

            // Auth use cases
            _ = services.AddTransient<IUseCase<LoginResponseDto, LoginRequestDto>, LoginUseCase>();

            // News use cases
            _ = services.AddTransient<IUseCase<GetAllNewsResponseDto, GetAllNewsRequestDto>, GetAllNewsUseCase>();
            _ = services.AddTransient<IUseCase<CreateNewsResponseDto, CreateNewsRequestDto>, CreateNewsUseCase>();
            _ = services.AddTransient<IUseCase<UpdateNewsResponseDto, UpdateNewsRequestDto>, UpdateNewsUseCase>();
            _ = services.AddTransient<IUseCase<DeleteNewsResponseDto, DeleteNewsRequestDto>, DeleteNewsUseCase>();

            // Role use cases
            _ = services.AddTransient<IUseCase<GetAllRolesResponseDto, GetAllRolesRequestDto>, GetAllRolesUseCase>();
            _ = services.AddTransient<IUseCase<CreateRoleResponseDto, CreateRoleRequestDto>, CreateRoleUseCase>();
            _ = services.AddTransient<IUseCase<UpdateRoleResponseDto, UpdateRoleRequestDto>, UpdateRoleUseCase>();
            _ = services.AddTransient<IUseCase<DeleteRoleResponseDto, DeleteRoleRequestDto>, DeleteRoleUseCase>();

            // System use cases
            _ = services.AddTransient<IUseCase<CheckSystemStatusResponseDto, CheckSystemStatusRequestDto>, CheckSystemStatusUseCase>();

            // User use cases
            _ = services.AddTransient<IUseCase<GetAllUsersResponseDto, GetAllUsersRequestDto>, GetAllUsersUseCase>();
            _ = services.AddTransient<IUseCase<CreateUserResponseDto, CreateUserRequestDto>, CreateUserUseCase>();
            _ = services.AddTransient<IUseCase<UpdateUserResponseDto, UpdateUserRequestDto>, UpdateUserUseCase>();
            _ = services.AddTransient<IUseCase<DeleteUserResponseDto, DeleteUserRequestDto>, DeleteUserUseCase>();


            return services;
        }

        /// <summary>
        /// Register inter-layers mappers
        /// </summary>
        /// <param name="services">Application service</param>
        /// <returns>Services with registered mappers</returns>
        public static IServiceCollection RegisterApplicationLayerMappers(this IServiceCollection services)
        {
            _ = services.AddTransient<IMapper<User, UserDto>, UserMapper>();

            return services;
        }
    }
}

