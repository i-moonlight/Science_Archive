using ScienceArchive.Core.Domain.Common.Identifiers;

namespace ScienceArchive.Core.Domain.Aggregates.User.ValueObjects;

public class UserId : GuidEntityId<UserId>
{
	private UserId(Guid value) : base(value)
	{
	}
}