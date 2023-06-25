using ScienceArchive.Core.Domain.Entities;

namespace ScienceArchive.Core.Services.RoleContracts;

/// <summary>
/// Contract to update role
/// </summary>
/// <param name="Id">ID of the role to update</param>
/// <param name="Role">New role</param>
public record UpdateRoleContract(Guid Id, Role Role);