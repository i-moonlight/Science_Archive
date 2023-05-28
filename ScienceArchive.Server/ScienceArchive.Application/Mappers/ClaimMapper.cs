using System;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Dtos.Claim;
using ScienceArchive.Core.Interfaces.Mappers;

namespace ScienceArchive.Application.Mappers
{
    public class ClaimMapper : IMapper<Claim, ClaimDto>
    {
        public ClaimDto MapToDto(Claim entity)
        {
            return new()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Value = entity.Value
            };
        }

        public Claim MapToEntity(ClaimDto dto, Guid? id = null)
        {
            return new(id)
            {
                Name = dto.Name,
                Description = dto.Description,
                Value = dto.Value
            };
        }
    }
}

