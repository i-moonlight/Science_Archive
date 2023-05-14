using System;
using ScienceArchive.Core.Dtos.UserRequest;
using ScienceArchive.Core.Dtos.UserResponse;
using ScienceArchive.Core.Domain.Entities;

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
        /// <param name="contract">Contract to create new user</param>
        /// <returns>Created user</returns>
        Task<CreateUserResponseDto> Create(CreateUserRequestDto contract);

        /// <summary>
        /// Update existing user
        /// </summary>
        /// <param name="contract">Contract to update user</param>
        /// <returns>Updated user</returns>
        Task<UpdateUserResponseDto> Update(UpdateUserRequestDto contract);

        /// <summary>
        /// Delete existing user
        /// </summary>
        /// <param name="contract">Contract to delete user</param>
        /// <returns>Deleted user ID</returns>
        Task<DeleteUserResponseDto> Delete(DeleteUserRequestDto contract);
    }
}

