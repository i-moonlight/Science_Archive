using ScienceArchive.Core.Domain.Common.Identifiers;

namespace ScienceArchive.Core.Domain.Aggregates.News.ValueObjects;

public sealed class NewsId : GuidEntityId<NewsId>
{
	private NewsId(Guid value) : base(value)
	{
	}
}