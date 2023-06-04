using System;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Dtos.News;
using ScienceArchive.Core.Dtos.Role;
using ScienceArchive.Core.Dtos.Role.Request;
using ScienceArchive.Core.Dtos.Role.Response;
using ScienceArchive.Core.Interfaces.Mappers;
using ScienceArchive.Core.Interfaces.Repositories;
using ScienceArchive.Core.Interfaces.UseCases;

namespace ScienceArchive.Application.RoleUseCases
{
    public class CreateRoleUseCase : IUseCase<CreateRoleResponseDto, CreateRoleRequestDto>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper<Role, RoleDto> _roleMapper;

        public CreateRoleUseCase(IRoleRepository roleRepository, IMapper<Role, RoleDto> roleMapper)
        {
            if (roleRepository is null)
            {
                throw new ArgumentNullException(nameof(roleRepository));
            }

            if (roleMapper is null)
            {
                throw new ArgumentNullException(nameof(roleMapper));
            }

            _roleRepository = roleRepository;
            _roleMapper = roleMapper;
        }

        public async Task<CreateRoleResponseDto> Execute(CreateRoleRequestDto dto)
        {
            var newRole = _roleMapper.MapToEntity(dto.Role);
            var createdRole = await _roleRepository.Create(newRole);

            return new(_roleMapper.MapToModel(createdRole));
        }
    }
}

