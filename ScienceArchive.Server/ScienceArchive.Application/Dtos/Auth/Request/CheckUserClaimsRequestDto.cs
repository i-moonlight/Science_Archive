namespace ScienceArchive.Application.Dtos.Auth.Request;

/// <summary>
/// Request DTO to check user claims
/// </summary>
public record CheckUserClaimsRequestDto
{
	/// <summary>
	/// User ID
	/// </summary>
	public required string UserId { get; set; }
	
	/// <summary>
	/// Required set of user claims
	/// </summary>
	public List<string>? RequiredClaims { get; set; }
}