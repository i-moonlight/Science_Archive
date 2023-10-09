using ScienceArchive.Core.Domain.Aggregates.User.ValueObjects;

namespace ScienceArchive.Core.Services.RoleContracts;

/// <summary>
/// Contract to get claims of user
/// </summary>
/// <param name="UserId">User ID</param>
public record GetUserClaimsContract(UserId UserId);