namespace ScienceArchive.Application.Dtos.Article.Response;

/// <summary>
/// Response DTO of getting articles by author ID
/// </summary>
/// <param name="Articles">Result set of articles with specified author ID</param>
public record GetArticlesByAuthorIdResponseDto(List<ArticleDto> Articles);