using System;
using ScienceArchive.Core.Dtos.User;

namespace ScienceArchive.Core.Dtos.UserResponse
{
    /// <summary>
    /// Response contract to create user request
    /// </summary>
    /// <param name="User">Created user</param>
    public record class CreateUserResponseDto(IdentifiedUserDto User);
}

