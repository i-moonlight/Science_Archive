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
    /// Get all users with their passwords
    /// </summary>
    /// <returns>Users entities with passwords</returns>
    Task<List<User>> GetAllUsersWithPasswords();

    /// <summary>
    /// Get users which are authors of any article
    /// </summary>
    /// <returns>All users which have written any article</returns>
    Task<List<Author>> GetAllAuthors();
}