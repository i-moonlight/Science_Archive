using System;
using ScienceArchive.Application.Dtos.System.Request;
using ScienceArchive.Application.Dtos.System.Response;
using ScienceArchive.Application.Interfaces.Interactors;

namespace ScienceArchive.Application.Interactors
{
    public class SystemInteractor : ISystemInteractor
    {
        public SystemInteractor()
        {
        }

        /// <inheritdoc/>
        public Task<CheckSystemStatusResponseDto> CheckSystemStatus(CheckSystemStatusRequestDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

