namespace ScienceArchive.Application.Dtos.Role.Request;

/// <summary>
/// Request contract to delete role
/// </summary>
/// <param name="Id">Identifier of the role to delete</param>
public record DeleteRoleRequestDto(string Id);