using System;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Dtos.Claim;
using ScienceArchive.Core.Dtos.Role;
using ScienceArchive.Core.Interfaces.Mappers;

namespace ScienceArchive.Application.Mappers
{
    public class RoleMapper : IMapper<Role, RoleDto>
    {
        private readonly IMapper<Claim, ClaimDto> _claimMapper;

        public RoleMapper(IMapper<Claim, ClaimDto> claimMapper)
        {
            _claimMapper = claimMapper;
        }

        public RoleDto MapToModel(Role entity)
        {
            var claimDtos = entity.Claims.Select((claim) => _claimMapper.MapToModel(claim)).ToList();

            return new()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Claims = claimDtos,
            };
        }

        public Role MapToEntity(RoleDto model, Guid? id = null)
        {
            var claims = model.Claims.Select((claimDto) => _claimMapper.MapToEntity(claimDto, claimDto.Id)).ToList();

            return new(id)
            {
                Name = model.Name,
                Description = model.Description,
                Claims = claims,
            };
        }
    }
}

