namespace ScienceArchive.Infrastructure.Persistence.PostgreSql.Models;

internal record ArticleModel
{
	/// <summary>
	/// Article identifier
	/// </summary>
	public required Guid Id { get; set; }
	
	/// <summary>
	/// Category of an article
	/// </summary>
	public required Guid CategoryId { get; set; }
	
	/// <summary>
	/// Article title
	/// </summary>
	public required string Title { get; set; }

	/// <summary>
	/// Article author
	/// </summary>
	public required List<Guid> AuthorsIds { get; set; }

	/// <summary>
	/// Date when article was created
	/// </summary>
	public required DateTime CreationDate { get; set; }

	/// <summary>
	/// Linked documents to articles
	/// </summary>
	public required List<ArticleDocumentModel> Documents { get; set; }
	
	/// <summary>
	/// Article description
	/// </summary>
	public string? Description { get; set; }
}