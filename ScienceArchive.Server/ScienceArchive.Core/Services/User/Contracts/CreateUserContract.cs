using ScienceArchive.Core.Domain.Aggregates.User;

namespace ScienceArchive.Core.Services.UserContracts;

/// <summary>
/// Contract to create new user
/// </summary>
/// <param name="User">User to create</param>
public record CreateUserContract(User User);