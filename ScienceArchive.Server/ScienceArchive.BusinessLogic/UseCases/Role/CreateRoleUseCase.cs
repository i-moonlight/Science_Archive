using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.RoleContracts;

namespace ScienceArchive.BusinessLogic.RoleUseCases;

public class CreateRoleUseCase : IUseCase<Role, CreateRoleContract>
{
    private readonly IRoleRepository _roleRepository;

    public CreateRoleUseCase(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
    }

    public async Task<Role> Execute(CreateRoleContract contract)
    {
        return await _roleRepository.Create(contract.Role);
    }
}