using ScienceArchive.Core.Domain.Aggregates.User;
using ScienceArchive.Core.Domain.Aggregates.User.ValueObjects;
using ScienceArchive.Core.Services.UserContracts;

namespace ScienceArchive.Core.Services;

/// <summary>
/// Contains a set of business-logic methods
/// to interact with users
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Get user with specified ID
    /// </summary>
    /// <param name="contract">Contract to get user with specified id</param>
    /// <returns>Found user if it exists, otherwise, null</returns>
    Task<User?> GetById(GetUserByIdContract contract);

    /// <summary>
    /// Get user by its credentials
    /// </summary>
    /// <param name="contract">Contract to get user by its credentials</param>
    /// <returns>Found user if it exists, otherwise, null</returns>
    Task<User?> GetUserByCredentials(GetUserByCredentialsContract contract);
    
    /// <summary>
    /// Get all existing users
    /// </summary>
    /// <param name="contract">Contract to get all users</param>
    /// <returns>All existing users</returns>
    Task<List<User>> GetAll(GetAllUsersContract contract);

    /// <summary>
    /// Get all existing users which are authors of any article
    /// </summary>
    /// <param name="contract">Contract to get all authors</param>
    /// <returns>All existing authors</returns>
    Task<List<Author>> GetAllAuthors(GetAllAuthorsContract contract);

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
    Task<UserId> Delete(DeleteUserContract contract);
}