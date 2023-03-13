using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScienceArchive.Infrastructure.Persistence.Models
{
    [Table("users")]
    public record class UserModel
    {
        /// <summary>
        /// ID of the user to update
        /// </summary>
        [Column("id")]
        public required Guid Id { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        [Column("name")]
        public required string Name { get; set; }

        /// <summary>
        /// User email
        /// </summary>
        [Column("email")]
        public required string Email { get; set; }

        /// <summary>
        /// User auth login
        /// </summary>
        [Column("login")]
        public required string Login { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        [Column("password")]
        public required string Password { get; set; }

        /// <summary>
        /// Salt for password
        /// </summary>
        [Column("password_salt")]
        public required string PasswordSalt { get; set; }
    }
}

