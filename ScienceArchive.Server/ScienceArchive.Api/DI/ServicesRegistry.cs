using ScienceArchive.Application.Services;
using ScienceArchive.Application.UseCases;
using ScienceArchive.Application.UseCases.System;
using ScienceArchive.Core.Dtos.System.Request;
using ScienceArchive.Core.Dtos.System.Response;
using ScienceArchive.Core.Dtos.User.Request;
using ScienceArchive.Core.Dtos.UserRequest;
using ScienceArchive.Core.Dtos.UserResponse;
using ScienceArchive.Core.Interfaces.Services;
using ScienceArchive.Core.Interfaces.UseCases;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Registry of services in system
    /// </summary>
    public static class ServicesRegistry
    {
        /// <summary>
        /// Register default services implementations
        /// </summary>
        /// <param name="services">Application services</param>
        /// <returns>Registered services</returns>
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            _ = services.AddTransient<IUserService, UserService>();
            _ = services.AddTransient<ISystemService, SystemService>();

            return services;
        }

        /// <summary>
        /// Register default Use Cases for services implementations
        /// </summary>
        /// <param name="services">Application services</param>
        /// <returns>Services with registered Use Cases</returns>
        public static IServiceCollection RegisterUseCases(this IServiceCollection services)
        {
            // User use cases
            _ = services.AddTransient<IUseCase<AuthorizeUserResponseDto, AuthorizeUserRequestDto>, AuthorizeUserUseCase>();
            _ = services.AddTransient<IUseCase<GetAllUsersResponseDto, GetAllUsersRequestDto>, GetAllUsersUseCase>();
            _ = services.AddTransient<IUseCase<CreateUserResponseDto, CreateUserRequestDto>, CreateUserUseCase>();
            _ = services.AddTransient<IUseCase<UpdateUserResponseDto, UpdateUserRequestDto>, UpdateUserUseCase>();
            _ = services.AddTransient<IUseCase<DeleteUserResponseDto, DeleteUserRequestDto>, DeleteUserUseCase>();

            // System use cases
            _ = services.AddTransient<IUseCase<CheckSystemStatusResponseDto, CheckSystemStatusRequestDto>, CheckSystemStatusUseCase>();

            return services;
        }
    }
}

