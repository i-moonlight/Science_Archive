namespace ScienceArchive.Core.Domain.ValueObjects;

/// <summary>
/// System status
/// </summary>
public class SystemStatus
{
    /// <summary>
    /// Is service working
    /// </summary>
    public required bool IsWorking { get; set; }
}