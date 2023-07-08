using ScienceArchive.Core.Domain.Common;

namespace ScienceArchive.Core.Domain.Entities;

/// <summary>
/// Role entity
/// </summary>
public class Role : BaseEntity
{
    public Role(Guid? id = null) : base(id)
    {
    }

    /// <summary>
    /// Role name
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Role claims. List of permissions
    /// of a user to perform some
    /// actions in the system
    /// </summary>
    public required List<Claim> Claims { get; init; }

    /// <summary>
    /// Role description
    /// </summary>
    public string? Description { get; set; }
}