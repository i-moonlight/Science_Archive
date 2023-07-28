using ScienceArchive.Core.Domain.Aggregates.Role.ValueObjects;
using ScienceArchive.Core.Domain.Aggregates.User.ValueObjects;
using ScienceArchive.Core.Domain.Common;
using ScienceArchive.Core.Domain.Utils;

namespace ScienceArchive.Core.Domain.Aggregates.User;

/// <summary>
/// User entity
/// </summary>
public class User : Entity<UserId>
{
    private string _name = string.Empty;
    private string _email = string.Empty;
    private string _login = string.Empty;

    public User(UserId? id = null) : base(id ?? UserId.CreateNew())
    {
    }

    /// <summary>
    /// Set of user roles identifiers
    /// </summary>
    public required List<RoleId> RoleIds { get; set; }
    
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
    /// User password
    /// </summary>
    public required UserPassword Password { get; set; }

    /// <summary>
    /// Does user have a password
    /// </summary>
    public bool HasOwnPassword => string.IsNullOrWhiteSpace(Password.Value);

    /// <summary>
    /// Does user have a password salt
    /// </summary>
    public bool HasOwnPasswordSalt => string.IsNullOrWhiteSpace(Password.Salt);
}