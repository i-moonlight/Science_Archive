using ScienceArchive.Core.Domain.Aggregates.User;
using ScienceArchive.Core.Domain.Aggregates.User.ValueObjects;
using ScienceArchive.Core.Repositories.Common;

namespace ScienceArchive.Core.Repositories;

/// <summary>
/// User repository functionality
/// </summary>
public interface IUserRepository : ICrudRepository<UserId, User>
{
    /// <summary>
    /// Get user with specified credentials
    /// </summary>
    /// <param name="login">User login</param>
    /// <returns>Found user if it exists, otherwise, null</returns>
    Task<User?> GetAuthUserByLogin(string login);

    /// <summary>
    /// Get users which are authors of any article
    /// </summary>
    /// <returns>All users which have written any article</returns>
    Task<List<Author>> GetAllAuthors();
}