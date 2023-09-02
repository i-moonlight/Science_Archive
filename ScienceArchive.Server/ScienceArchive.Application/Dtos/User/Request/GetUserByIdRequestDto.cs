namespace ScienceArchive.Application.Dtos.User.Request;

/// <summary>
/// Request contract to get user by its ID
/// </summary>
/// <param name="Id">ID of a user to find</param>
public record GetUserByIdRequestDto(string Id);