using System;
namespace ScienceArchive.Core.Dtos.UserRequest
{
    public record class AuthorizeUserRequestDto
    {
        /// <summary>
        /// User auth login or email
        /// </summary>
        public required string Login { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        public required string Password { get; set; }
    }
}

