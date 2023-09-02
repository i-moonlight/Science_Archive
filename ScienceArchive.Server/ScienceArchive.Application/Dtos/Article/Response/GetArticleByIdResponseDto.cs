namespace ScienceArchive.Application.Dtos.Article.Response;

/// <summary>
/// Response contract of getting article by ID
/// </summary>
/// <param name="Article">Found article. If no article was found, return null</param>
public record GetArticleByIdResponseDto(ArticleDto? Article);