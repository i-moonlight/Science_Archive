using System;
using ScienceArchive.Application.Dtos;

namespace ScienceArchive.Application.Dtos.User.Response
{
    /// <summary>
    /// Response contract to create user request
    /// </summary>
    /// <param name="User">Created user</param>
    public record class CreateUserResponseDto(UserDto User);
}

