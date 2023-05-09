using System;
using ScienceArchive.Core.Dtos.User;

namespace ScienceArchive.Core.Dtos.UserResponse
{
    /// <summary>
    /// Response contract to update user request
    /// </summary>
    /// <param name="user">Updated user</param>
    public record UpdateUserResponseDto(IdentifiedUserDto User);
}

