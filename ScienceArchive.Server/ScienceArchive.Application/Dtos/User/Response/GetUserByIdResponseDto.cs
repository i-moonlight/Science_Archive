namespace ScienceArchive.Application.Dtos.User.Response;

/// <summary>
/// Response contract of getting user by its ID
/// </summary>
/// <param name="User">Found user. If no user was found, return null</param>
public record GetUserByIdResponseDto(UserDto? User);