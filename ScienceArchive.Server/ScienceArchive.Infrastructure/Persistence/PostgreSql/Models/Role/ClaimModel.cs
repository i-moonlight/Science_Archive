using System.Text.Json.Serialization;

namespace ScienceArchive.Infrastructure.Persistence.PostgreSql.Models;

internal record ClaimModel
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