using ScienceArchive.Core.Domain.Aggregates.User.ValueObjects;

namespace ScienceArchive.Core.Services.UserContracts;

/// <summary>
/// Contract to delete user
/// </summary>
/// <param name="Id">User ID to delete</param>
public record DeleteUserContract(UserId Id);