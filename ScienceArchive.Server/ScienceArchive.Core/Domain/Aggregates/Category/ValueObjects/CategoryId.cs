using ScienceArchive.Core.Domain.Common.Identifiers;

namespace ScienceArchive.Core.Domain.Aggregates.Category.ValueObjects;

public sealed class CategoryId : GuidEntityId<CategoryId>
{
	public CategoryId(Guid value) : base(value)
	{
	}
}