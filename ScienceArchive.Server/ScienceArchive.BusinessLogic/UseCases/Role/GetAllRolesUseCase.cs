using System;
using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.RoleContracts;

namespace ScienceArchive.BusinessLogic.RoleUseCases
{
    public class GetAllRolesUseCase : IUseCase<List<Role>, GetAllRolesContract>
    {
        private readonly IRoleRepository _roleRepository;

        public GetAllRolesUseCase(IRoleRepository roleRepository)
        {
            if (roleRepository is null)
            {
                throw new ArgumentNullException(nameof(roleRepository));
            }

            _roleRepository = roleRepository;
        }

        public async Task<List<Role>> Execute(GetAllRolesContract contract)
        {
            return await _roleRepository.GetAll();
        }
    }
}

