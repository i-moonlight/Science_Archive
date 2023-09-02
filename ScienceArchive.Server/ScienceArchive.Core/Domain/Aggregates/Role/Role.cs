using ScienceArchive.Core.Domain.Aggregates.Role.ValueObjects;
using ScienceArchive.Core.Domain.Common;

namespace ScienceArchive.Core.Domain.Aggregates.Role;

/// <summary>
/// Role entity
/// </summary>
public class Role : Entity<RoleId>
{
    public Role(RoleId? id = null) : base(id ?? RoleId.CreateNew())
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
    public required List<RoleClaimId> ClaimsIds { get; init; }

    /// <summary>
    /// Role description
    /// </summary>
    public string? Description { get; set; }
}