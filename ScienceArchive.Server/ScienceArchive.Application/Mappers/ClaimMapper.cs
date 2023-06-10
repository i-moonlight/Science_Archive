using System;
using ScienceArchive.Application.Dtos.Claim;
using ScienceArchive.Application.Interfaces;
using ScienceArchive.Core.Domain.Entities;

namespace ScienceArchive.Application.Mappers
{
    public class ClaimMapper : IApplicationMapper<Claim, ClaimDto>
    {
        public ClaimDto MapToDto(Claim entity)
        {
            return new()
            {
                Id = entity.Id.ToString(),
                Name = entity.Name,
                Description = entity.Description,
                Value = entity.Value
            };
        }

        public Claim MapToEntity(ClaimDto dto, string? id = null)
        {
            Guid? claimId = id is not null
                ? new Guid(id)
                : null;

            return new(claimId)
            {
                Name = dto.Name,
                Description = dto.Description,
                Value = dto.Value
            };
        }
    }
}

