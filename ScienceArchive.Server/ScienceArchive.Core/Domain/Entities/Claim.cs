using ScienceArchive.Core.Domain.Common;

namespace ScienceArchive.Core.Domain.Entities;

/// <summary>
/// Claim entity. Represents permission of
/// doing some actions in the system
/// </summary>
public class Claim : BaseEntity
{
    public Claim(Guid? id = null) : base(id) { }

    /// <summary>
    /// Claim value
    /// </summary>
    public required string Value { get; init; }

    /// <summary>
    /// Claim name
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Claim description
    /// </summary>
    public string? Description { get; set; }
}