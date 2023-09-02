using ScienceArchive.Core.Domain.Common.Identifiers;

namespace ScienceArchive.Core.Domain.Aggregates.Role.ValueObjects;

public sealed class RoleId : GuidEntityId<RoleId>
{
	public RoleId(Guid value) : base(value)
	{
	}
}