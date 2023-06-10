using System;
using ScienceArchive.Application.Dtos.Role.Request;
using ScienceArchive.Application.Dtos.Role.Response;
using ScienceArchive.Application.Interfaces.Interactors;

namespace ScienceArchive.Application.Interactors
{
    public class RoleInteractor : IRoleInteractor
    {
        public RoleInteractor()
        {
        }

        /// <inheritdoc/>
        public Task<CreateRoleResponseDto> CreateRole(CreateRoleRequestDto dto)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<DeleteRoleResponseDto> DeleteRole(DeleteRoleRequestDto dto)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<GetAllRolesResponseDto> GetAllRoles(GetAllRolesRequestDto dto)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<UpdateRoleResponseDto> UpdateRole(UpdateRoleRequestDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

