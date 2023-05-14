using System;
namespace ScienceArchive.Core.Dtos.Role.Response
{
    /// <summary>
    /// Response contract of roles update
    /// </summary>
    /// <param name="Role">Updated role</param>
    public record UpdateRoleResponseDto(RoleDto Role);
}

