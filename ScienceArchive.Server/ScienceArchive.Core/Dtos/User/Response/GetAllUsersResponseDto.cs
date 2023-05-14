using System;
using ScienceArchive.Core.Dtos.User;

namespace ScienceArchive.Core.Dtos.UserResponse
{
    /// <summary>
    /// Response contract to get all users request
    /// </summary>
    /// <param name="Users">Users</param>
    public record GetAllUsersResponseDto(List<UserDto> Users);
}

