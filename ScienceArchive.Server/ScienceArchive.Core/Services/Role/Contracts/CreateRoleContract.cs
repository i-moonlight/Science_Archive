using System;
using ScienceArchive.Core.Domain.Entities;

namespace ScienceArchive.Core.Services.RoleContracts
{
    /// <summary>
    /// Contract to create new role
    /// </summary>
    /// <param name="Role">Role to create</param>
    public record CreateRoleContract(Role Role);
}

