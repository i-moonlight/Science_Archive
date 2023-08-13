using ScienceArchive.Core.Domain.Aggregates.Role;
using ScienceArchive.Core.Domain.Aggregates.Role.ValueObjects;
using ScienceArchive.Infrastructure.Persistence.Interfaces;
using ScienceArchive.Infrastructure.Persistence.PostgreSql.Models;

namespace ScienceArchive.Infrastructure.Persistence.PostgreSql.Mappers;

public class RoleMapper : IPersistenceMapper<Role, RoleModel>
{
	private readonly IPersistenceMapper<RoleClaim, ClaimModel> _claimMapper;

	public RoleMapper(IPersistenceMapper<RoleClaim, ClaimModel> claimMapper)
	{
		_claimMapper = claimMapper ?? throw new ArgumentNullException(nameof(claimMapper));
	}

	public RoleModel MapToModel(Role entity)
	{
		var claims = entity.Claims.Select(claim => _claimMapper.MapToModel(claim)).ToList(); 
			
		return new()
		{
			Id = entity.Id.Value,
			Name = entity.Name,
			Description = entity.Description,
			Claims = claims
		};
	}

	public Role MapToEntity(RoleModel model)
	{
		var roleId = RoleId.CreateFromGuid(model.Id);
		var claims = model.Claims.Select(claim => _claimMapper.MapToEntity(claim)).ToList();

		return new(roleId)
		{
			Name = model.Name,
			Description = model.Description,
			Claims = claims
		};
	}
}