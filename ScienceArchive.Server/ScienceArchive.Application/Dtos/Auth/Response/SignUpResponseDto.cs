using System;
namespace ScienceArchive.Application.Dtos.Auth.Response
{
    /// <summary>
    /// Response contract to sign up user
    /// </summary>
    /// <param name="User">Signed up (created) user</param>
    public record SignUpResponseDto(UserDto User);
}

