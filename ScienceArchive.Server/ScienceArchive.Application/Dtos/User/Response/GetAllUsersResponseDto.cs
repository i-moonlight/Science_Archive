using System;
using ScienceArchive.Application.Dtos;

namespace ScienceArchive.Application.Dtos.User.Response
{
    /// <summary>
    /// Response contract to get all users request
    /// </summary>
    /// <param name="Users">Users</param>
    public record GetAllUsersResponseDto(List<UserDto> Users);
}

