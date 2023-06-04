using System;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Dtos.Role;
using ScienceArchive.Core.Dtos.Role.Request;
using ScienceArchive.Core.Dtos.Role.Response;
using ScienceArchive.Core.Interfaces.Mappers;
using ScienceArchive.Core.Interfaces.Repositories;
using ScienceArchive.Core.Interfaces.UseCases;

namespace ScienceArchive.Application.RoleUseCases
{
    public class GetAllRolesUseCase : IUseCase<GetAllRolesResponseDto, GetAllRolesRequestDto>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper<Role, RoleDto> _roleMapper;

        public GetAllRolesUseCase(IRoleRepository roleRepository, IMapper<Role, RoleDto> roleMapper)
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

        public async Task<GetAllRolesResponseDto> Execute(GetAllRolesRequestDto dto)
        {
            var roles = await _roleRepository.GetAll();
            var rolesDtos = roles.Select(role => _roleMapper.MapToModel(role)).ToList();

            return new(rolesDtos);
        }
    }
}

