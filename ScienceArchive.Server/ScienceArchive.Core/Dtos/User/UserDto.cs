using System;
namespace ScienceArchive.Core.Dtos
{
    /// <summary>
    /// User DTO
    /// </summary>
    /// <param name="Name">User name</param>
    /// <param name="Email">User email</param>
    /// <param name="Login">User auth login</param>
    public record UserDto(string Name, string Email, string Login);
}
