using ScienceArchive.Core.Domain.Common.Identifiers;

namespace ScienceArchive.Core.Domain.Aggregates.Article.ValueObjects;

/// <summary>
/// Identifier of an article
/// </summary>
public sealed class ArticleId : GuidEntityId<ArticleId>
{
	public ArticleId(Guid value) : base(value)
	{
	}
}
