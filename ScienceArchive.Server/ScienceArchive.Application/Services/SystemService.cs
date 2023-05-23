using System;
using ScienceArchive.Core.Dtos.System.Request;
using ScienceArchive.Core.Dtos.System.Response;
using ScienceArchive.Core.Interfaces.Services;
using ScienceArchive.Core.Interfaces.UseCases;

namespace ScienceArchive.Application.Services
{
    public class SystemService : BaseService, ISystemService
    {
        public SystemService(IServiceProvider serviceProvider) : base(serviceProvider) { }

        /// <inheritdoc/>
        public async Task<CheckSystemStatusResponseDto> CheckSystemStatus()
        {
            var emptyDto = new CheckSystemStatusRequestDto();
            return await ExecuteUseCase<CheckSystemStatusResponseDto, CheckSystemStatusRequestDto>(emptyDto);
        }
    }
}

