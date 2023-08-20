using ScienceArchive.Core.Domain.Common.Identifiers;

namespace ScienceArchive.Core.Domain.Aggregates.User.ValueObjects;

public sealed class UserId : GuidEntityId<UserId>
{
	public UserId(Guid value) : base(value)
	{
	}
}