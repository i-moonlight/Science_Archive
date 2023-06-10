using System;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Services;
using ScienceArchive.Core.Services.AuthContracts;

namespace ScienceArchive.BusinessLogic.Services
{
    public class AuthService : BaseService, IAuthService
    {
        public AuthService(IServiceProvider serviceProvider) : base(serviceProvider) { }

        /// <inheritdoc/>
        public async Task<User> Login(LoginContract contract)
        {
            return await ExecuteUseCase<User, LoginContract>(contract);
        }
    }
}

