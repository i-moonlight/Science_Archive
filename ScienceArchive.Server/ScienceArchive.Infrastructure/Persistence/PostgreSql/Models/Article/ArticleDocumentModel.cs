using System.Text.Json.Serialization;

namespace ScienceArchive.Infrastructure.Persistence.PostgreSql.Models;

internal class ArticleDocumentModel
{
	/// <summary>
	/// Path to a document linked to article
	/// </summary>
	[JsonPropertyName("document_path")]
	public required string DocumentPath { get; set; }
}