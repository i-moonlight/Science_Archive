namespace ScienceArchive.Application.Dtos.User.Request;

/// <summary>
/// Request contract to create user
/// </summary>
/// <param name="User">User to create</param>
/// <param name="Password">User password</param>
public record CreateUserRequestDto(UserDto User, string Password);