using System;
namespace ScienceArchive.Core.Services.AuthContracts
{
    /// <summary>
    /// Contract to login
    /// </summary>
    /// <param name="Login">Username or email of user</param>
    /// <param name="Password">Password of the user</param>
    public record LoginContract(string Login, string Password);
}
