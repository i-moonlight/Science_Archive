using System;
using ScienceArchive.Core.Dtos.Role.Request;
using ScienceArchive.Core.Dtos.Role.Response;
using ScienceArchive.Core.Interfaces.UseCases;

namespace ScienceArchive.Application.UseCases.Role
{
    public class DeleteRoleUseCase : IUseCase<DeleteRoleResponseDto, DeleteRoleRequestDto>
    {
        public DeleteRoleUseCase()
        {
        }

        public Task<DeleteRoleResponseDto> Execute(DeleteRoleRequestDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

