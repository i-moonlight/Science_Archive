using System;
using ScienceArchive.Core.Dtos.Role.Request;
using ScienceArchive.Core.Dtos.Role.Response;
using ScienceArchive.Core.Interfaces.Services;

namespace ScienceArchive.Application.Services
{
    public class RoleService : BaseService, IRoleService
    {
        public RoleService(IServiceProvider serviceProvider) : base(serviceProvider) { }

        /// <inheritdoc/>
        public async Task<GetAllRolesResponseDto> GetAll(GetAllRolesRequestDto contract)
        {
            return await ExecuteUseCase<GetAllRolesResponseDto, GetAllRolesRequestDto>(contract);
        }

        /// <inheritdoc/>
        public async Task<CreateRoleResponseDto> Create(CreateRoleRequestDto contract)
        {
            return await ExecuteUseCase<CreateRoleResponseDto, CreateRoleRequestDto>(contract);
        }

        /// <inheritdoc/>
        public async Task<UpdateRoleResponseDto> Update(UpdateRoleRequestDto contract)
        {
            return await ExecuteUseCase<UpdateRoleResponseDto, UpdateRoleRequestDto>(contract);
        }

        /// <inheritdoc/>
        public async Task<DeleteRoleResponseDto> Delete(DeleteRoleRequestDto contract)
        {
            return await ExecuteUseCase<DeleteRoleResponseDto, DeleteRoleRequestDto>(contract);
        }
    }
}

