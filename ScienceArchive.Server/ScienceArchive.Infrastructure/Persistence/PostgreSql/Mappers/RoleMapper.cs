using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Infrastructure.Persistence.Interfaces;
using ScienceArchive.Infrastructure.Persistence.PostgreSql.Models;

namespace ScienceArchive.Infrastructure.Persistence.PostgreSql.Mappers;

public class RoleMapper : IPersistenceMapper<Role, RoleModel>
{
	private readonly IPersistenceMapper<Claim, ClaimModel> _claimMapper;

	public RoleMapper(IPersistenceMapper<Claim, ClaimModel> claimMapper)
	{
		_claimMapper = claimMapper ?? throw new ArgumentNullException(nameof(claimMapper));
	}

	public RoleModel MapToModel(Role entity)
	{
		var claims = entity.Claims.Select(claim => _claimMapper.MapToModel(claim)).ToList(); 
			
		return new()
		{
			Id = entity.Id,
			Name = entity.Name,
			Description = entity.Description,
			Claims = claims
		};
	}

	public Role MapToEntity(RoleModel model, Guid? id = null)
	{
		var claims = model.Claims.Select(claim => _claimMapper.MapToEntity(claim)).ToList();

		return new(id)
		{
			Name = model.Name,
			Description = model.Description,
			Claims = claims
		};
	}
}