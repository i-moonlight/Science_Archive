using ScienceArchive.Core.Domain.Common;

namespace ScienceArchive.Core.Domain.Aggregates.Article.ValueObjects;

public class ArticleDocument : ValueObject
{
	/// <summary>
	/// Path to a document linked to article
	/// </summary>
	public required string DocumentPath { get; set; }
}