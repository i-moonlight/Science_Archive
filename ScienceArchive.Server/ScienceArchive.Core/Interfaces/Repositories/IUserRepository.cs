using System;
using ScienceArchive.Core.Domain.Entities;

namespace ScienceArchive.Core.Interfaces.Repositories
{
    /// <summary>
    /// User repository base functionality
    /// </summary>
    public interface IUserRepository : IBaseRepository<User>
    {
        /// <summary>
        /// Get all users with their passwords
        /// </summary>
        /// <returns>Users entities with passwords</returns>
        Task<List<User>> GetAllUsersWithPasswords();
    }
}

