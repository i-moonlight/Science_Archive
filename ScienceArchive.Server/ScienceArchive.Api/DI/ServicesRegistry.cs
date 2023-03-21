using ScienceArchive.Application.Services;
using ScienceArchive.Application.UseCases;
using ScienceArchive.Core.Interfaces.Services;

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
            _ = services.AddTransient<AuthorizeUserUseCase>();
            _ = services.AddTransient<GetAllUsersUseCase>();
            _ = services.AddTransient<CreateUserUseCase>();
            _ = services.AddTransient<UpdateUserUseCase>();
            _ = services.AddTransient<DeleteUserUseCase>();

            return services;
        }
    }
}

