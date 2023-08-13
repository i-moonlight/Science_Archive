namespace ScienceArchive.Infrastructure.Persistence.PostgreSql.Models;

public class ArticleDocumentModel
{
	/// <summary>
	/// Path to a document linked to article
	/// </summary>
	public required string DocumentPath { get; set; }
}