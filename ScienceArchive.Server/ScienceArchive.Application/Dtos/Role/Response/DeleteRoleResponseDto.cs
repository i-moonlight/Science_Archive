namespace ScienceArchive.Application.Dtos.Role.Response;

/// <summary>
/// Response contract of role deletion
/// </summary>
/// <param name="Id">Identifier of the role to delete</param>
public record DeleteRoleResponseDto(Guid Id);