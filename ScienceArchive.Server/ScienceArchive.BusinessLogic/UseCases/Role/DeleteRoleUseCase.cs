using System;
using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.RoleContracts;

namespace ScienceArchive.BusinessLogic.RoleUseCases
{
    public class DeleteRoleUseCase : IUseCase<Guid, DeleteRoleContract>
    {
        private readonly IRoleRepository _roleRepository;

        public DeleteRoleUseCase(IRoleRepository roleRepository)
        {
            if (roleRepository is null)
            {
                throw new ArgumentNullException(nameof(roleRepository));
            }

            _roleRepository = roleRepository;
        }

        public async Task<Guid> Execute(DeleteRoleContract contract)
        {
            return await _roleRepository.Delete(contract.RoleId);
        }
    }
}

