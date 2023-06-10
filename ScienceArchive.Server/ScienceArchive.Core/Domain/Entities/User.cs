using System;
using ScienceArchive.Core.Domain.Common;
using ScienceArchive.Core.Domain.Utils;

namespace ScienceArchive.Core.Domain.Entities
{
    /// <summary>
    /// User entity
    /// </summary>
    public class User : BaseEntity
    {
        private string _name = string.Empty;
        private string _email = string.Empty;
        private string _login = string.Empty;
        private string _password = string.Empty;
        private string _passwordSalt = string.Empty;

        public User(Guid? id = null, string? passwordSalt = null) : base(id)
        {
        }

        /// <summary>
        /// Name of the user
        /// </summary>
        public required string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name must not be empty or containing only whitespaces");
                }

                _name = value.Trim();
            }
        }

        /// <summary>
        /// E-mail of the user
        /// </summary>
        public required string Email
        {
            get => _email;
            set
            {
                if (!StringValidator.IsEmail(value))
                {
                    throw new Exception("Email value is invalid!");
                }

                _email = value.Trim();
            }
        }

        /// <summary>
        /// Login of the user which is used to authorize
        /// </summary>
        public required string Login
        {
            get => _login;
            set => _login = value.Trim();
        }

        /// <summary>
        ///	Hash of the salted user password
        /// </summary>
        public string Password
        {
            get => _password;
            set => _password = value;
        }

        /// <summary>
        /// Salt for password
        /// </summary>
        public string PasswordSalt
        {
            get => _passwordSalt;
            set => _passwordSalt = value;
        }

        /// <summary>
        /// Has user a password
        /// </summary>
        public bool HasOwnPassword
        {
            get => String.IsNullOrWhiteSpace(_password);
        }

        /// <summary>
        /// Has user a password salt
        /// </summary>
        public bool HasOwnPasswordSalt
        {
            get => String.IsNullOrWhiteSpace(_passwordSalt);
        }
    }
}

