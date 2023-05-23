using System;
using ScienceArchive.Core.Dtos.Role.Request;
using ScienceArchive.Core.Dtos.Role.Response;
using ScienceArchive.Core.Interfaces.UseCases;

namespace ScienceArchive.Application.UseCases.Role
{
    public class UpdateRoleUseCase : IUseCase<UpdateRoleResponseDto, UpdateRoleRequestDto>
    {
        public UpdateRoleUseCase()
        {
        }

        public Task<UpdateRoleResponseDto> Execute(UpdateRoleRequestDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

