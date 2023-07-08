namespace ScienceArchive.Infrastructure.Persistence.PostgreSql.Models;

public record ArticleModel
{
	/// <summary>
	/// Article identifier
	/// </summary>
	public required Guid Id { get; set; }
	
	/// <summary>
	/// Article title
	/// </summary>
	public required string Title { get; set; }
	
	/// <summary>
	/// Article author
	/// </summary>
	public required Guid AuthorId { get; set; }
	
	/// <summary>
	/// Date when article was created
	/// </summary>
	public required DateTime CreationDate { get; set; }
	
	/// <summary>
	/// Article description
	/// </summary>
	public string? Description { get; set; }
	
	/// <summary>
	/// Article document path
	/// </summary>
	public string? DocumentPath { get; set; }
}