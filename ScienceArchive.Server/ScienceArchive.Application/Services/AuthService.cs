using System;
using ScienceArchive.Core.Dtos.Auth.Request;
using ScienceArchive.Core.Dtos.Auth.Response;
using ScienceArchive.Core.Interfaces.Services;
using ScienceArchive.Core.Interfaces.UseCases;

namespace ScienceArchive.Application.Services
{
    public class AuthService : IAuthService
    {
        IUseCase<LoginResponseDto, LoginRequestDto> _loginUseCase;

        public AuthService(IUseCase<LoginResponseDto, LoginRequestDto> loginUseCase)
        {
            _loginUseCase = loginUseCase;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto contract)
        {
            return await _loginUseCase.Execute(contract);
        }
    }
}

