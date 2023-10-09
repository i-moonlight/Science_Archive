using ScienceArchive.Core.Domain.Aggregates.Role;
using ScienceArchive.Core.Domain.Aggregates.Role.ValueObjects;
using ScienceArchive.Core.Services;
using ScienceArchive.Core.Services.RoleContracts;

namespace ScienceArchive.BusinessLogic.Services;

internal class RoleService : BaseService, IRoleService
{
    public RoleService(IServiceProvider serviceProvider) : base(serviceProvider) { }

    /// <inheritdoc/>
    public async Task<List<Role>> GetAll(GetAllRolesContract contract)
    {
        return await ExecuteUseCase<List<Role>, GetAllRolesContract>(contract);
    }

    /// <inheritdoc/>
    public async Task<List<RoleClaim>> GetUserClaims(GetUserClaimsContract contract)
    {
        return await ExecuteUseCase<List<RoleClaim>, GetUserClaimsContract>(contract);
    }

    /// <inheritdoc/>
    public async Task<Role> Create(CreateRoleContract contract)
    {
        return await ExecuteUseCase<Role, CreateRoleContract>(contract);
    }

    /// <inheritdoc/>
    public async Task<Role> Update(UpdateRoleContract contract)
    {
        return await ExecuteUseCase<Role, UpdateRoleContract>(contract);
    }

    /// <inheritdoc/>
    public async Task<RoleId> Delete(DeleteRoleContract contract)
    {
        return await ExecuteUseCase<RoleId, DeleteRoleContract>(contract);
    }
}