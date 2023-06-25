namespace ScienceArchive.Application.Dtos.User.Request;

/// <summary>
/// Request contract to update user
/// </summary>
/// <param name="User">User data</param>
public record class UpdateUserRequestDto(Guid UserId, UserDto User);