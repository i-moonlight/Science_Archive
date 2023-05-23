using System;
using ScienceArchive.Core.Dtos.Auth.Request;
using ScienceArchive.Core.Dtos.Auth.Response;
using ScienceArchive.Core.Interfaces.Services;
using ScienceArchive.Core.Interfaces.UseCases;

namespace ScienceArchive.Application.Services
{
    public class AuthService : BaseService, IAuthService
    {
        public AuthService(IServiceProvider serviceProvider) : base(serviceProvider) { }

        public async Task<LoginResponseDto> Login(LoginRequestDto contract)
        {
            return await ExecuteUseCase<LoginResponseDto, LoginRequestDto>(contract);
        }
    }
}

