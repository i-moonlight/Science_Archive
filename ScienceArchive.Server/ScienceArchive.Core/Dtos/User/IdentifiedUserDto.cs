using System;
namespace ScienceArchive.Core.Dtos.User
{
    /// <summary>
    /// User DTO with identifier
    /// </summary>
    /// <param name="Id">ID of the user</param>
    /// <param name="Name">User name</param>
    /// <param name="Email">User email</param>
    /// <param name="Login">User auth login</param>
    public record IdentifiedUserDto(Guid Id, string Name, string Email, string Login)
        : UserDto(Name, Email, Login);
}

