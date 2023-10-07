namespace ScienceArchive.Infrastructure.Persistence.PostgreSql.Models;

internal record NewsModel
{
	/// <summary>
	/// News identifier
	/// </summary>
	public required Guid Id { get; set; }
	
	/// <summary>
	/// Creator ID
	/// </summary>
	public required Guid AuthorId { get; set; }
	
	/// <summary>
	/// News title
	/// </summary>
	public required string Title { get; set; }
	
	/// <summary>
	/// News body
	/// </summary>
	public required string Body { get; set; }
	
	/// <summary>
	/// Date when news were created
	/// </summary>
	public required DateTime CreationDate { get; set; }
	
	/// <summary>
	/// Date when news were updated last time
	/// </summary>
	public required DateTime? LastUpdatedDate { get; set; }
}