using System;
namespace ScienceArchive.Core.Dtos.Role.Response
{
    /// <summary>
    /// Response contract of getting all roles
    /// </summary>
    /// <param name="Roles">All existing roles</param>
    public record GetAllRolesResponseDto(List<RoleDto> Roles);
}

