namespace ScienceArchive.Application.Dtos;

/// <summary>
/// User DTO
/// </summary>
public record UserDto
{
    /// <summary>
    /// User ID
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// List of user roles identifiers
    /// </summary>
    public List<string>? RolesIds { get; set; }
    
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
}