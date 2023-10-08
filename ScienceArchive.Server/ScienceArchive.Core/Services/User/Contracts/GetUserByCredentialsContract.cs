namespace ScienceArchive.Core.Services.UserContracts;

/// <summary>
/// Contract to get user by its credentials
/// </summary>
/// <param name="Login">User login</param>
/// <param name="Password">User password</param>
public record GetUserByCredentialsContract(string Login, string Password);