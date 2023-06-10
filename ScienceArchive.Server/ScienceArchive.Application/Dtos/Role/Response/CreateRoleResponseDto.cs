using System;
namespace ScienceArchive.Application.Dtos.Role.Response
{
    /// <summary>
    /// Response contract of role creation
    /// </summary>
    /// <param name="Role">Created role</param>
    public record CreateRoleResponseDto(RoleDto Role);
}

