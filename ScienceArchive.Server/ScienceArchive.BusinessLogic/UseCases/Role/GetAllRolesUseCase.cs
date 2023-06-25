﻿using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.RoleContracts;

namespace ScienceArchive.BusinessLogic.RoleUseCases;

public class GetAllRolesUseCase : IUseCase<List<Role>, GetAllRolesContract>
{
    private readonly IRoleRepository _roleRepository;

    public GetAllRolesUseCase(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
    }

    public async Task<List<Role>> Execute(GetAllRolesContract contract)
    {
        return await _roleRepository.GetAll();
    }
}