using ScienceArchive.Core.Domain.Aggregates.Role;
using ScienceArchive.Core.Domain.Aggregates.Role.ValueObjects;

namespace ScienceArchive.Core.Services.RoleContracts;

/// <summary>
/// Contract to update role
/// </summary>
/// <param name="Id">ID of the role to update</param>
/// <param name="Role">New role</param>
public record UpdateRoleContract(RoleId Id, Role Role);