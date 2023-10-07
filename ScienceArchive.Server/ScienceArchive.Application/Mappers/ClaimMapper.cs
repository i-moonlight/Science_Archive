using ScienceArchive.Application.Dtos.Claim;
using ScienceArchive.Application.Interfaces;
using ScienceArchive.Core.Domain.Aggregates.Role.ValueObjects;

namespace ScienceArchive.Application.Mappers;

internal class ClaimMapper : IApplicationMapper<RoleClaim, ClaimDto>
{
    public ClaimDto MapToDto(RoleClaim entity)
    {
        return new()
        {
            Id = entity.Id.ToString(),
            Name = entity.Name,
            Description = entity.Description,
            Value = entity.Value
        };
    }

    public RoleClaim MapToEntity(ClaimDto dto)
    {
        var claimId = RoleClaimId.CreateFromString(dto.Id);

        return new(claimId)
        {
            Name = dto.Name,
            Description = dto.Description,
            Value = dto.Value
        };
    }
}