using ScienceArchive.Core.Domain.Common.Identifiers;

namespace ScienceArchive.Core.Domain.Aggregates.Role.ValueObjects;

public sealed class RoleId : GuidEntityId<RoleId>
{
	private RoleId(Guid value) : base(value)
	{
	}
}