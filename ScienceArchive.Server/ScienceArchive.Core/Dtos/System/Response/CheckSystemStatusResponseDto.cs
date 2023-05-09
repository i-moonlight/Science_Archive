using System;
namespace ScienceArchive.Core.Dtos.System.Response
{
    /// <summary>
    /// Represents system status check response
    /// </summary>
    public record CheckSystemStatusResponseDto(bool IsWorking);
}

