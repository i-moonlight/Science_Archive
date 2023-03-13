using System;
using ScienceArchive.Core.Entities;

namespace ScienceArchive.Core.Interfaces.Repositories
{
    /// <summary>
    /// Represents user repository
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Get user by ID
        /// </summary>
        /// <param name="userId">ID of the user to find</param>
        /// <returns>User with specified ID</returns>
        Task<User> GetById(Guid userId);

        /// <summary>
        /// Get all existing users
        /// </summary>
        /// <returns>Existing users</returns>
        Task<List<User>> GetAll();

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="newUser">New user to create</param>
        /// <returns>Created user</returns>
        Task<User> Create(User newUser);

        /// <summary>
        /// Update existing user
        /// </summary>
        /// <param name="userId">ID of the user to update</param>
        /// <param name="newUser">User data to update</param>
        /// <returns>Updated user</returns>
        Task<User> Update(Guid userId, User newUser);

        /// <summary>
        /// Delete existing user
        /// </summary>
        /// <param name="userId">ID of the user to delete</param>
        /// <returns>Deleted user ID</returns>
        Task<Guid> Delete(Guid userId);
    }
}

