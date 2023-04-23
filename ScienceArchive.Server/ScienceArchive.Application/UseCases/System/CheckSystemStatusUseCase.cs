using System;
using ScienceArchive.Core.Dtos.System.Request;
using ScienceArchive.Core.Dtos.System.Response;
using ScienceArchive.Core.Interfaces.UseCases;

namespace ScienceArchive.Application.UseCases.System
{
    public class CheckSystemStatusUseCase : IUseCase<CheckSystemStatusResponseDto, CheckSystemStatusRequestDto>
    {
        public CheckSystemStatusUseCase()
        {
        }

        public Task<CheckSystemStatusResponseDto> Execute(CheckSystemStatusRequestDto dto)
        {
            return Task.FromResult<CheckSystemStatusResponseDto>(new CheckSystemStatusResponseDto { Working = true });
        }
    }
}

