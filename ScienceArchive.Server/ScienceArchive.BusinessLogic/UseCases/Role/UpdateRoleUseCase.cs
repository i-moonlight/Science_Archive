using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Domain.Aggregates.Role;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.RoleContracts;

namespace ScienceArchive.BusinessLogic.RoleUseCases;

internal class UpdateRoleUseCase : IUseCase<Role, UpdateRoleContract>
{
    private readonly IRoleRepository _roleRepository;

    public UpdateRoleUseCase(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
    }

    public async Task<Role> Execute(UpdateRoleContract contract)
    {
        return await _roleRepository.Update(contract.Id, contract.Role);
    }
}