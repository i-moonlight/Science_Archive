using System;
namespace ScienceArchive.Core.Dtos.Auth.Request
{
    /// <summary>
    /// Login request contract
    /// </summary>
    /// <param name="Login">User auth login or email</param>
    /// <param name="Password">User password</param>
    public record LoginRequestDto(string Login, string Password);
}

