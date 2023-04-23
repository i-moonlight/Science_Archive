using System;
namespace ScienceArchive.Core.Dtos.System.Response
{
    /// <summary>
    /// Represents system status check response
    /// </summary>
    public record class CheckSystemStatusResponseDto
    {
        /// <summary>
        /// Is the service working
        /// </summary>
        public required bool Working { get; set; }
    }
}

