namespace ScienceArchive.Application.Dtos.Auth.Request;

/// <summary>
/// Sign up request contract
/// </summary>
/// <param name="User">New user to sign up</param>
public record SignUpRequestDto(UserDto User, string Password);