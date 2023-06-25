using ScienceArchive.Core.Domain.Entities;

namespace ScienceArchive.Core.Services.UserContracts;

/// <summary>
/// Contract to update user
/// </summary>
/// <param name="Id">User ID to update</param>
/// <param name="User">New user</param>
public record UpdateUserContract(Guid Id, User User);