namespace ScienceArchive.Application.Dtos.Role.Request;

/// <summary>
/// Request contract to update role
/// </summary>
/// <param name="Id">Identifier of the role to update</param>
/// <param name="Role">New role data to update</param>
public record UpdateRoleRequestDto(string Id, RoleDto Role);