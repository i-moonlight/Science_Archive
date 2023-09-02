using ScienceArchive.Core.Domain.Aggregates.Role.ValueObjects;
using ScienceArchive.Infrastructure.Persistence.Interfaces;
using ScienceArchive.Infrastructure.Persistence.PostgreSql.Models;

namespace ScienceArchive.Infrastructure.PostgreSql.PersistenceMappers;

public class ClaimMapper : IPersistenceMapper<RoleClaim, ClaimModel>
{
	public ClaimModel MapToModel(RoleClaim entity)
	{
		return new()
		{
			Id = entity.Id.Value,
			Value = entity.Value,
			Description = entity.Description,
			Name = entity.Name
		};
	}

	public RoleClaim MapToEntity(ClaimModel model)
	{
		var claimId = RoleClaimId.CreateFromGuid(model.Id);
		
		return new(claimId)
		{
			Value = model.Value,
			Description = model.Description,
			Name = model.Name
		};
	}
}