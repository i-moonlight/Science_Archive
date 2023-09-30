namespace ScienceArchive.Application.Dtos.Article.Request;

/// <summary>
/// DTO contract to get articles by author ID
/// </summary>
/// <param name="AuthorId">Author ID</param>
public record GetArticlesByAuthorIdRequestDto(string AuthorId);