namespace ScienceArchive.Application.Dtos.User.Response;

/// <summary>
/// Response contract to update user request
/// </summary>
/// <param name="user">Updated user</param>
public record UpdateUserResponseDto(UserDto User);