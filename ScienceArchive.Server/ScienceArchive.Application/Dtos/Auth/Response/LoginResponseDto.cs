namespace ScienceArchive.Application.Dtos.Auth.Response;

/// <summary>
/// Response contract to login request
/// </summary>
/// <param name="User">Found user</param>
public record LoginResponseDto(UserDto User);