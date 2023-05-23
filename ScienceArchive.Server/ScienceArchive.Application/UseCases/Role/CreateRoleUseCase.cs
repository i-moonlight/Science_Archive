using System;
using ScienceArchive.Core.Dtos.Role.Request;
using ScienceArchive.Core.Dtos.Role.Response;
using ScienceArchive.Core.Interfaces.UseCases;

namespace ScienceArchive.Application.UseCases.Role
{
    public class CreateRoleUseCase : IUseCase<CreateRoleResponseDto, CreateRoleRequestDto>
    {
        public CreateRoleUseCase()
        {
        }

        public Task<CreateRoleResponseDto> Execute(CreateRoleRequestDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

