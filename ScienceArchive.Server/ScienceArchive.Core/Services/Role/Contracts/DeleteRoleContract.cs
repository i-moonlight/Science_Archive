namespace ScienceArchive.Core.Services.RoleContracts;

/// <summary>
/// Contract to delete role
/// </summary>
/// <param name="RoleId">Role ID to delete</param>
public record DeleteRoleContract(Guid RoleId);