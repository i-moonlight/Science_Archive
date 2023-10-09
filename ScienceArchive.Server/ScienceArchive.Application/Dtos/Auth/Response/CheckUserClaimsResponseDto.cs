namespace ScienceArchive.Application.Dtos.Auth.Response;

/// <summary>
/// Response DTO of checking user claims
/// </summary>
/// <param name="Success">True if user contains all required claims, otherwise, false</param>
public record CheckUserClaimsResponseDto(bool Success);