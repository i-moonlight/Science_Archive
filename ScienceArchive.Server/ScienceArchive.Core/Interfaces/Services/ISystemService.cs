using System;
using ScienceArchive.Core.Dtos.System.Response;

namespace ScienceArchive.Core.Interfaces.Services
{
    /// <summary>
    /// SystemService provides necessary
    /// functionality to system operations
    /// </summary>
    public interface ISystemService
    {
        /// <summary>
        /// Check current system status
        /// </summary>
        /// <returns>The system check report</returns>
        Task<CheckSystemStatusResponseDto> CheckSystemStatus();
    }
}

