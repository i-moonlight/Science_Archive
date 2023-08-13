using ScienceArchive.Core.Domain.Common.Identifiers;

namespace ScienceArchive.Core.Domain.Aggregates.Role.ValueObjects;

public sealed class RoleClaimId : GuidEntityId<RoleClaimId>
{
	public RoleClaimId(Guid value) : base(value)
	{
	}
}