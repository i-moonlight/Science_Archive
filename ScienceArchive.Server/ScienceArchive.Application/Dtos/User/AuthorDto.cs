namespace ScienceArchive.Application.Dtos;

/// <summary>
/// Author DTO
/// </summary>
public record AuthorDto
{
	/// <summary>
	/// Id of author
	/// </summary>
	public required string Id { get; set; }
	
	/// <summary>
	/// Name of author
	/// </summary>
	public required string Name { get; set; }
	
	/// <summary>
	/// Description of author
	/// </summary>
	public string? Description { get; set; }
	
	/// <summary>
	/// List of IDs of all author's articles
	/// </summary>
	public required List<string> ArticlesIds { get; set; }
}