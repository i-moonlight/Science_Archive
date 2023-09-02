using ScienceArchive.Application.Dtos.Role.Request;
using ScienceArchive.Application.Dtos.Role.Response;

namespace ScienceArchive.Application.Interfaces.Interactors;

/// <summary>
/// Application role interactor
/// </summary>
public interface IRoleInteractor
{
    /// <summary>
    /// Get all roles
    /// </summary>
    /// <param name="dto">DTO contract to get all roles</param>
    /// <returns>Response DTO</returns>
    Task<GetAllRolesResponseDto> GetAllRoles(GetAllRolesRequestDto dto);

    /// <summary>
    /// Create new role
    /// </summary>
    /// <param name="dto">DTO contract to create role</param>
    /// <returns>Response DTO</returns>
    Task<CreateRoleResponseDto> CreateRole(CreateRoleRequestDto dto);

    /// <summary>
    /// Update existing role
    /// </summary>
    /// <param name="dto">DTO contract to update role</param>
    /// <returns>Response DTO</returns>
    Task<UpdateRoleResponseDto> UpdateRole(UpdateRoleRequestDto dto);

    /// <summary>
    /// Delete existing role
    /// </summary>
    /// <param name="dto">DTO contract to delete role</param>
    /// <returns>Response DTO</returns>
    Task<DeleteRoleResponseDto> DeleteRole(DeleteRoleRequestDto dto);
}