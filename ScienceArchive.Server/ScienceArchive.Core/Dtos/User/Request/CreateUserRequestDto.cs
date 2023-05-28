using System;
namespace ScienceArchive.Core.Dtos.User.Request
{
    /// <summary>
    /// Request contract to create user
    /// </summary>
    /// <param name="User">User to create</param>
    /// <param name="Password">User password</param>
    public record class CreateUserRequestDto(UserDto User, string Password);
}

