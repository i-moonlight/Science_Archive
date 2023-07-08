using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Infrastructure.Persistence.Interfaces;
using ScienceArchive.Infrastructure.Persistence.PostgreSql.Models;

namespace ScienceArchive.Infrastructure.Persistence.PostgreSql.Mappers;

public class ClaimMapper : IPersistenceMapper<Claim, ClaimModel>
{
	public ClaimModel MapToModel(Claim entity)
	{
		return new()
		{
			Id = entity.Id,
			Value = entity.Value,
			Description = entity.Description,
			Name = entity.Name
		};
	}

	public Claim MapToEntity(ClaimModel model, Guid? id = null)
	{
		return new(id)
		{
			Value = model.Value,
			Description = model.Description,
			Name = model.Name
		};
	}
}