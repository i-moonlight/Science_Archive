using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Services.AuthContracts;

namespace ScienceArchive.Core.Services;

/// <summary>
/// Functionality of auth service
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Check if user exist
    /// </summary>
    /// <param name="contract">Contract to login user</param>
    /// <returns>Found by credentials user</returns>
    Task<User> Login(LoginContract contract);
}