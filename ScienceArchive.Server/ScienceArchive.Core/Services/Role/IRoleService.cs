using ScienceArchive.Core.Domain.Aggregates.Role;
using ScienceArchive.Core.Domain.Aggregates.Role.ValueObjects;
using ScienceArchive.Core.Services.RoleContracts;

namespace ScienceArchive.Core.Services;

/// <summary>
/// Contains a set of business-logic methods
/// to interact with roles
/// </summary>
public interface IRoleService
{
    /// <summary>
    /// Get all roles
    /// </summary>
    /// <param name="contract">Contract to get all roles</param>
    /// <returns>All roles</returns>
    Task<List<Role>> GetAll(GetAllRolesContract contract);

    /// <summary>
    /// Get all user claims
    /// </summary>
    /// <param name="contract">Contract to get all user claims</param>
    /// <returns>User claims</returns>
    Task<List<RoleClaim>> GetUserClaims(GetUserClaimsContract contract);
    
    /// <summary>
    /// Create role
    /// </summary>
    /// <param name="contract">Contract to create role</param>
    /// <returns>Created role</returns>
    Task<Role> Create(CreateRoleContract contract);

    /// <summary>
    /// Update role
    /// </summary>
    /// <param name="contract">Contract to update role</param>
    /// <returns>Update role response contract</returns>
    Task<Role> Update(UpdateRoleContract contract);

    /// <summary>
    /// Delete role
    /// </summary>
    /// <param name="contract">Contract to delete role</param>
    /// <returns>Deleted role ID</returns>
    Task<RoleId> Delete(DeleteRoleContract contract);
}