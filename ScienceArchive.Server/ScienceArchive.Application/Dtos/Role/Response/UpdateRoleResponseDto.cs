using System;
namespace ScienceArchive.Application.Dtos.Role.Response
{
    /// <summary>
    /// Response contract of roles update
    /// </summary>
    /// <param name="Role">Updated role</param>
    public record UpdateRoleResponseDto(RoleDto Role);
}

