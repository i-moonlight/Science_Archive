namespace ScienceArchive.Application.Dtos.Article.Response;

/// <summary>
/// Response DTO of getting articles by category ID
/// </summary>
/// <param name="Articles"></param>
public record GetArticlesByCategoryIdResponseDto(List<ArticleDto> Articles);