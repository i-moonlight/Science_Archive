using System;
using ScienceArchive.Core.Entities;

namespace ScienceArchive.Core.Dtos.UserResponse
{
    public record class AuthorizeUserResponseDto
    {
        /// <summary>
        /// The result of the checking
        /// </summary>
        public bool UserExist { get; set; }

        /// <summary>
        /// Found user
        /// </summary>
        public UserDto? User { get; set; }
    }
}

