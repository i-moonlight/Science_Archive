using ScienceArchive.Core.Domain.Aggregates.Role.ValueObjects;

namespace ScienceArchive.Core.Services.RoleContracts;

/// <summary>
/// Contract to delete role
/// </summary>
/// <param name="Id">Role ID to delete</param>
public record DeleteRoleContract(RoleId Id);