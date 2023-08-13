namespace ScienceArchive.Application.Dtos.User.Request;

/// <summary>
/// Request contract to delete user
/// </summary>
/// <param name="Id">ID of the user to delete</param>
public record class DeleteUserRequestDto(string Id);