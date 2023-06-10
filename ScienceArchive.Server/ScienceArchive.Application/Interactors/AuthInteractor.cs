using System;
using ScienceArchive.Application.Dtos.Auth.Request;
using ScienceArchive.Application.Dtos.Auth.Response;
using ScienceArchive.Application.Interfaces.Interactors;

namespace ScienceArchive.Application.Interactors
{
    public class AuthInteractor : IAuthInteractor
    {
        public AuthInteractor()
        {
        }

        /// <inheritdoc/>
        public Task<LoginResponseDto> Login(LoginRequestDto dto)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<SignUpResponseDto> SignUp(SignUpRequestDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

