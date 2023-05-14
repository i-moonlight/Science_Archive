using System;
using ScienceArchive.Core.Dtos.Role.Request;
using ScienceArchive.Core.Dtos.Role.Response;

namespace ScienceArchive.Core.Interfaces.Services
{
    /// Base functionality of role service
    public interface IRoleService
    {
        /// <summary>
        /// Get all roles
        /// </summary>
        /// <param name="contract">Request contract to get all roles</param>
        /// <returns>Get all roles response contract</returns>
        Task<GetAllRolesResponseDto> GetAll(GetAllRolesRequestDto contract);

        /// <summary>
        /// Create role
        /// </summary>
        /// <param name="contract">Request contract to create role</param>
        /// <returns>Create role response contract</returns>
        Task<CreateRoleResponseDto> Create(CreateRoleRequestDto contract);

        /// <summary>
        /// Update role
        /// </summary>
        /// <param name="contract">Request contract to update role</param>
        /// <returns>Update role response contract</returns>
        Task<UpdateRoleResponseDto> Update(UpdateRoleRequestDto contract);

        /// <summary>
        /// Delete role
        /// </summary>
        /// <param name="contract">Request contract to delete role</param>
        /// <returns>Delete role response contract</returns>
        Task<DeleteRoleResponseDto> Delete(DeleteRoleRequestDto contract);
    }
}

