using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Services.UserContracts;

namespace ScienceArchive.Core.Services;

/// <summary>
/// Represents user service
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Get all existing users
    /// </summary>
    /// <param name="contract">Contract to get all users</param>
    /// <returns>All existing users</returns>
    Task<List<User>> GetAll(GetAllUsersContract contract);

    /// <summary>
    /// Create new user
    /// </summary>
    /// <param name="contract">Contract to create user</param>
    /// <returns>Created user</returns>
    Task<User> Create(CreateUserContract contract);

    /// <summary>
    /// Update existing user
    /// </summary>
    /// <param name="contract">Contract to update user</param>
    /// <returns>Updated user</returns>
    Task<User> Update(UpdateUserContract contract);

    /// <summary>
    /// Delete existing user
    /// </summary>
    /// <param name="contract">Contract to delete user</param>
    /// <returns>Deleted user ID</returns>
    Task<Guid> Delete(DeleteUserContract contract);
}