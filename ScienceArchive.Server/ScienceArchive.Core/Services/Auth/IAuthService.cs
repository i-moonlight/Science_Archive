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
    Task<Domain.Aggregates.User.User> Login(LoginContract contract);
}