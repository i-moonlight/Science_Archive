using System;
namespace ScienceArchive.Core.Services.UserContracts
{
    /// <summary>
    /// Contract to delete user
    /// </summary>
    /// <param name="UserId">User ID to delete</param>
    public record DeleteUserContract(Guid UserId);
}

