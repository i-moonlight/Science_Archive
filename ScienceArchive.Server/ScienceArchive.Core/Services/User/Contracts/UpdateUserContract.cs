using ScienceArchive.Core.Domain.Aggregates.User;
using ScienceArchive.Core.Domain.Aggregates.User.ValueObjects;

namespace ScienceArchive.Core.Services.UserContracts;

/// <summary>
/// Contract to update user
/// </summary>
/// <param name="Id">User ID to update</param>
/// <param name="User">New user</param>
public record UpdateUserContract(UserId Id, User User);