using ScienceArchive.Core.Domain.Aggregates.User;
using ScienceArchive.Core.Services.AuthContracts;

namespace ScienceArchive.Core.Services;

/// <summary>
/// Contains a set of business-logic methods
/// to interact with authentication
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