using System;
using ScienceArchive.Application.Dtos.Claim;
using ScienceArchive.Application.Dtos.Role;
using ScienceArchive.Application.Interfaces;
using ScienceArchive.Core.Domain.Entities;

namespace ScienceArchive.Application.Mappers
{
    public class RoleMapper : IApplicationMapper<Role, RoleDto>
    {
        private readonly IApplicationMapper<Claim, ClaimDto> _claimMapper;

        public RoleMapper(IApplicationMapper<Claim, ClaimDto> claimMapper)
        {
            _claimMapper = claimMapper;
        }

        public RoleDto MapToDto(Role entity)
        {
            var claimDtos = entity.Claims.Select((claim) => _claimMapper.MapToDto(claim)).ToList();

            return new()
            {
                Id = entity.Id.ToString(),
                Name = entity.Name,
                Description = entity.Description,
                Claims = claimDtos,
            };
        }

        public Role MapToEntity(RoleDto model, string? id = null)
        {
            var claims = model.Claims.Select((claimDto) => _claimMapper.MapToEntity(claimDto, claimDto.Id)).ToList();

            Guid? roleId = id is not null
                ? new Guid(id)
                : null;

            return new(roleId)
            {
                Name = model.Name,
                Description = model.Description,
                Claims = claims,
            };
        }
    }
}

