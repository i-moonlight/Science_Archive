using ScienceArchive.Core.Domain.Common.Identifiers;

namespace ScienceArchive.Core.Domain.Aggregates.Category.ValueObjects;

public class CategoryId : GuidEntityId<CategoryId>
{
	public CategoryId(Guid value) : base(value)
	{
	}
}