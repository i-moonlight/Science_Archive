using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Domain.Aggregates.Role.ValueObjects;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.RoleContracts;

namespace ScienceArchive.BusinessLogic.RoleUseCases;

internal class DeleteRoleUseCase : IUseCase<RoleId, DeleteRoleContract>
{
    private readonly IRoleRepository _roleRepository;

    public DeleteRoleUseCase(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
    }

    public async Task<RoleId> Execute(DeleteRoleContract contract)
    {
        return await _roleRepository.Delete(contract.Id);
    }
}