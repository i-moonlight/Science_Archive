using System;
using ScienceArchive.Core.Dtos.UserRequest;
using ScienceArchive.Core.Dtos.UserResponse;
using ScienceArchive.Core.Entities;

namespace ScienceArchive.Core.Interfaces.Services
{
    /// <summary>
    /// Represents user service
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Get all existing users
        /// </summary>
        /// <returns>All existing users</returns>
        Task<GetAllUsersResponseDto> GetAll();

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="newUser">New user to create</param>
        /// <returns>Created user</returns>
        Task<CreateUserResponseDto> Create(CreateUserRequestDto contract);

        /// <summary>
        /// Update existing user
        /// </summary>
        /// <param name="userId">User ID to update</param>
        /// <param name="newUser">New user data</param>
        /// <returns>Updated user</returns>
        Task<UpdateUserResponseDto> Update(UpdateUserRequestDto contract);

        /// <summary>
        /// Delete existing user
        /// </summary>
        /// <param name="userId">User ID to delete</param>
        /// <returns>Deleted user ID</returns>
        Task<DeleteUserResponseDto> Delete(DeleteUserRequestDto contract);
    }
}

