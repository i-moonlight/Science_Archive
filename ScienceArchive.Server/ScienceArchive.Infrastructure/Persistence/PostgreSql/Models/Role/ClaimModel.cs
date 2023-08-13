namespace ScienceArchive.Infrastructure.Persistence.PostgreSql.Models;

public record ClaimModel
{
	/// <summary>
	/// Claim identifier
	/// </summary>
	public required Guid Id { get; set; }

	/// <summary>
	/// Claim value
	/// </summary>
	public required string Value { get; set; }

	/// <summary>
	/// Claim name
	/// </summary>
	public string? Name { get; set; }

	/// <summary>
	/// Claim description
	/// </summary>
	public string? Description { get; set; }
}