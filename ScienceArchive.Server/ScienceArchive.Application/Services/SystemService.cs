using System;
using ScienceArchive.Core.Dtos.System.Request;
using ScienceArchive.Core.Dtos.System.Response;
using ScienceArchive.Core.Interfaces.Services;
using ScienceArchive.Core.Interfaces.UseCases;

namespace ScienceArchive.Application.Services
{
    public class SystemService : ISystemService
    {
        private readonly IUseCase<CheckSystemStatusResponseDto, CheckSystemStatusRequestDto> _checkSystemStatusUseCase;

        public SystemService(
            IUseCase<CheckSystemStatusResponseDto, CheckSystemStatusRequestDto> checkSystemStatusUseCase)
        {
            _checkSystemStatusUseCase = checkSystemStatusUseCase;
        }

        public async Task<CheckSystemStatusResponseDto> CheckSystemStatus()
        {
            var emptyDto = new CheckSystemStatusRequestDto();

            return await _checkSystemStatusUseCase.Execute(emptyDto);
        }
    }
}

