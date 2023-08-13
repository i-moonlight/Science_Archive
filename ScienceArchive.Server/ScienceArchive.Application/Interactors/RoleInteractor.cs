using ScienceArchive.Application.Dtos.Role;
using ScienceArchive.Application.Dtos.Role.Request;
using ScienceArchive.Application.Dtos.Role.Response;
using ScienceArchive.Application.Interfaces;
using ScienceArchive.Application.Interfaces.Interactors;
using ScienceArchive.Core.Domain.Aggregates.Role;
using ScienceArchive.Core.Domain.Aggregates.Role.ValueObjects;
using ScienceArchive.Core.Services;
using ScienceArchive.Core.Services.RoleContracts;

namespace ScienceArchive.Application.Interactors
{
    public class RoleInteractor : IRoleInteractor
    {
        private readonly IRoleService _roleService;
        private readonly IApplicationMapper<Role, RoleDto> _roleMapper;

        public RoleInteractor(IRoleService roleService, IApplicationMapper<Role, RoleDto> roleMapper)
        {
            _roleService = roleService ?? throw new ArgumentNullException(nameof(roleService));
            _roleMapper = roleMapper ?? throw new ArgumentNullException(nameof(roleMapper));
        }

        /// <inheritdoc/>
        public async Task<CreateRoleResponseDto> CreateRole(CreateRoleRequestDto dto)
        {
            var contract = new CreateRoleContract(_roleMapper.MapToEntity(dto.Role));
            var createdRole = await _roleService.Create(contract);

            return new(_roleMapper.MapToDto(createdRole));
        }

        /// <inheritdoc/>
        public async Task<DeleteRoleResponseDto> DeleteRole(DeleteRoleRequestDto dto)
        {
            var contract = new DeleteRoleContract(RoleId.CreateFromString(dto.Id));
            var deletedRoleId = await _roleService.Delete(contract);

            return new(deletedRoleId.ToString());
        }

        /// <inheritdoc/>
        public async Task<GetAllRolesResponseDto> GetAllRoles(GetAllRolesRequestDto dto)
        {
            var contract = new GetAllRolesContract();
            var roles = await _roleService.GetAll(contract);
            var rolesDtos = roles.Select(role => _roleMapper.MapToDto(role)).ToList();

            return new(rolesDtos);
        }

        /// <inheritdoc/>
        public async Task<UpdateRoleResponseDto> UpdateRole(UpdateRoleRequestDto dto)
        {
            var contract = new UpdateRoleContract(RoleId.CreateFromString(dto.Id), _roleMapper.MapToEntity(dto.Role));
            var updatedRole = await _roleService.Update(contract);

            return new(_roleMapper.MapToDto(updatedRole));
        }
    }
}

