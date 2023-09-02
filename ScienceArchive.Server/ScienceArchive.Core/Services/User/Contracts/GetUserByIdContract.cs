using ScienceArchive.Core.Domain.Aggregates.User.ValueObjects;

namespace ScienceArchive.Core.Services.UserContracts;

/// <summary>
/// Contract to get user with specified ID
/// </summary>
/// <param name="Id">ID of user to find</param>
public record GetUserByIdContract(UserId Id);