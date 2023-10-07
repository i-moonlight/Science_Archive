using ScienceArchive.Core.Domain.Aggregates.Role;
using ScienceArchive.Core.Domain.Aggregates.Role.ValueObjects;
using ScienceArchive.Infrastructure.Persistence.Interfaces;
using ScienceArchive.Infrastructure.Persistence.PostgreSql.Models;

namespace ScienceArchive.Infrastructure.PostgreSql.PersistenceMappers;

internal class RoleMapper : IPersistenceMapper<Role, RoleModel>
{
	private readonly IPersistenceMapper<RoleClaim, ClaimModel> _claimMapper;

	public RoleMapper(IPersistenceMapper<RoleClaim, ClaimModel> claimMapper)
	{
		_claimMapper = claimMapper ?? throw new ArgumentNullException(nameof(claimMapper));
	}

	public RoleModel MapToModel(Role entity)
	{
		var claimsIds = entity.ClaimsIds.Select(claimId => claimId.Value).ToList(); 
			
		return new()
		{
			Id = entity.Id.Value,
			Name = entity.Name,
			Description = entity.Description,
			ClaimsIds = claimsIds
		};
	}

	public Role MapToEntity(RoleModel model)
	{
		var roleId = RoleId.CreateFromGuid(model.Id);
		var claimsIds = model.ClaimsIds.Select(RoleClaimId.CreateFromGuid).ToList();

		return new(roleId)
		{
			Name = model.Name,
			Description = model.Description,
			ClaimsIds = claimsIds
		};
	}
}