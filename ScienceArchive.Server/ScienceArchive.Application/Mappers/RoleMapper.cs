using ScienceArchive.Application.Dtos.Claim;
using ScienceArchive.Application.Dtos.Role;
using ScienceArchive.Application.Interfaces;
using ScienceArchive.Core.Domain.Aggregates.Role;
using ScienceArchive.Core.Domain.Aggregates.Role.ValueObjects;

namespace ScienceArchive.Application.Mappers;

public class RoleMapper : IApplicationMapper<Role, RoleDto>
{
    private readonly IApplicationMapper<RoleClaim, ClaimDto> _claimMapper;

    public RoleMapper(IApplicationMapper<RoleClaim, ClaimDto> claimMapper)
    {
        _claimMapper = claimMapper ?? throw new ArgumentNullException(nameof(claimMapper));
    }

    public RoleDto MapToDto(Role entity)
    {
        var claimDtos = entity.Claims.Select((claim) => _claimMapper.MapToDto(claim)).ToList();

        return new()
        {
            Id = entity.Id.ToString(),
            Name = entity.Name,
            Description = entity.Description,
            Claims = claimDtos
        };
    }

    public Role MapToEntity(RoleDto model)
    {
        var claims = model.Claims.Select((claimDto) => _claimMapper.MapToEntity(claimDto)).ToList();

        var roleId = model.Id is not null
            ? RoleId.CreateFromString(model.Id)
            : RoleId.CreateNew();
        
        return new(roleId)
        {
            Name = model.Name,
            Description = model.Description,
            Claims = claims
        };
    }
}