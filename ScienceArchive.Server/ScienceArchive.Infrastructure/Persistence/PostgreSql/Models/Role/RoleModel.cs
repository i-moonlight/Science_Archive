namespace ScienceArchive.Infrastructure.Persistence.PostgreSql.Models;

public record RoleModel
{
	/// <summary>
	/// Role identifier
	/// </summary>
	public required Guid Id { get; set; }

	/// <summary>
	/// Role name
	/// </summary>
	public required string Name { get; set; }

	/// <summary>
	/// Role claims
	/// </summary>
	public required List<Guid> ClaimsIds { get; set; }

	/// <summary>
	/// Role description
	/// </summary>
	public string? Description { get; set; }
}