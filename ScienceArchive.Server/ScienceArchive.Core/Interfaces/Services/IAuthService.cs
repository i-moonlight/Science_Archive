using System;
using ScienceArchive.Core.Dtos.Auth.Request;
using ScienceArchive.Core.Dtos.Auth.Response;

namespace ScienceArchive.Core.Interfaces.Services
{
    /// <summary>
    /// Base functionality of auth service
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Check if user exist
        /// </summary>
        /// <param name="contract">Data to check user</param>
        /// <returns>Checking result</returns>
        Task<LoginResponseDto> Login(LoginRequestDto contract);
    }
}

