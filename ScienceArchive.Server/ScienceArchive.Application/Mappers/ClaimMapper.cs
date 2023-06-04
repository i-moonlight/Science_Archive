using System;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Dtos.Claim;
using ScienceArchive.Core.Interfaces.Mappers;

namespace ScienceArchive.Application.Mappers
{
    public class ClaimMapper : IMapper<Claim, ClaimDto>
    {
        public ClaimDto MapToModel(Claim entity)
        {
            return new()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Value = entity.Value
            };
        }

        public Claim MapToEntity(ClaimDto model, Guid? id = null)
        {
            return new(id)
            {
                Name = model.Name,
                Description = model.Description,
                Value = model.Value
            };
        }
    }
}

