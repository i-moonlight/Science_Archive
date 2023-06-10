using System;
using ScienceArchive.Application.Dtos.System.Request;
using ScienceArchive.Application.Dtos.System.Response;

namespace ScienceArchive.Application.Interfaces.Interactors
{
    /// <summary>
    /// Application system interactor
    /// </summary>
    public interface ISystemInteractor
    {
        /// <summary>
        /// Check system status
        /// </summary>
        /// <param name="dto">DTO contract to check system status</param>
        /// <returns>Response DTO</returns>
        Task<CheckSystemStatusResponseDto> CheckSystemStatus(CheckSystemStatusRequestDto dto);
    }
}

