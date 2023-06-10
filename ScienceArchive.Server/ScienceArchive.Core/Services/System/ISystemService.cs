using System;
using ScienceArchive.Core.Domain.ValueObjects;
using ScienceArchive.Core.Services.SystemContracts;

namespace ScienceArchive.Core.Services
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
        /// <param name="contract">Contract to check system status</param>
        /// <returns>The system check report</returns>
        Task<SystemStatus> CheckSystemStatus(CheckSystemStatusContract contract);
    }
}

