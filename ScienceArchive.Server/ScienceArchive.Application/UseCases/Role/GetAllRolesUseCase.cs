using System;
using ScienceArchive.Core.Dtos.Role.Request;
using ScienceArchive.Core.Dtos.Role.Response;
using ScienceArchive.Core.Interfaces.UseCases;

namespace ScienceArchive.Application.UseCases.Role
{
    public class GetAllRolesUseCase : IUseCase<GetAllRolesResponseDto, GetAllRolesRequestDto>
    {
        public GetAllRolesUseCase()
        {
        }

        public Task<GetAllRolesResponseDto> Execute(GetAllRolesRequestDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

