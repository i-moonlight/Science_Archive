namespace ScienceArchive.Infrastructure.Persistence.PostgreSql.Models;

public record AuthorModel
{
	/// <summary>
	/// Id of author
	/// </summary>
	public required Guid Id { get; set; }
	
	/// <summary>
	/// Name of author
	/// </summary>
	public required string Name { get; set; }
	
	/// <summary>
	/// List of IDs of all author's articles
	/// </summary>
	public required List<Guid> ArticlesIds { get; set; }
}