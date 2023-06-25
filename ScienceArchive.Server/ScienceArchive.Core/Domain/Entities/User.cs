using System;
using ScienceArchive.Core.Domain.Common;
using ScienceArchive.Core.Domain.Utils;

namespace ScienceArchive.Core.Domain.Entities;

/// <summary>
/// User entity
/// </summary>
public class User : BaseEntity
{
    private string _name = string.Empty;
    private string _email = string.Empty;
    private string _login = string.Empty;

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
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Salt for password
    /// </summary>
    public string PasswordSalt { get; set; } = string.Empty;

    /// <summary>
    /// Has user a password
    /// </summary>
    public bool HasOwnPassword => string.IsNullOrWhiteSpace(Password);

    /// <summary>
    /// Has user a password salt
    /// </summary>
    public bool HasOwnPasswordSalt => string.IsNullOrWhiteSpace(PasswordSalt);
}