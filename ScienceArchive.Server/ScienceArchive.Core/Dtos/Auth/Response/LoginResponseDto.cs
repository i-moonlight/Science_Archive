using System;
using ScienceArchive.Core.Dtos.User;

namespace ScienceArchive.Core.Dtos.Auth.Response
{
    /// <summary>
    /// Response contract to login request
    /// </summary>
    /// <param name="User">Found user</param>
    public record LoginResponseDto(IdentifiedUserDto User);
}

