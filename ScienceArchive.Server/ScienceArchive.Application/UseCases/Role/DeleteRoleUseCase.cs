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
    public class DeleteRoleUseCase : IUseCase<DeleteRoleResponseDto, DeleteRoleRequestDto>
    {
        private readonly IRoleRepository _roleRepository;

        public DeleteRoleUseCase(IRoleRepository roleRepository, IMapper<Role, RoleDto> roleMapper)
        {
            if (roleRepository is null)
            {
                throw new ArgumentNullException(nameof(roleRepository));
            }

            _roleRepository = roleRepository;
        }

        public async Task<DeleteRoleResponseDto> Execute(DeleteRoleRequestDto dto)
        {
            var deletedRoleId = await _roleRepository.Delete(dto.Id);

            return new(deletedRoleId);
        }
    }
}

