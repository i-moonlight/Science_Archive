using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScienceArchive.Infrastructure.Persistence.Models
{
    public record class UserModel
    {
        /// <summary>
        /// ID of the user to update
        /// </summary>
        public required Guid Id { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// User email
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// User auth login
        /// </summary>
        public required string Login { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Salt for password
        /// </summary>
        public string? PasswordSalt { get; set; }
    }
}

