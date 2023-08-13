using ScienceArchive.Core.Domain.Common;

namespace ScienceArchive.Core.Domain.Aggregates.Role.ValueObjects;

/// <summary>
/// Represents permission of
/// doing some actions in the system
/// </summary>
public class RoleClaim : Entity<RoleClaimId>
{
	public RoleClaim(RoleClaimId id) : base(id)
	{
	}
	
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