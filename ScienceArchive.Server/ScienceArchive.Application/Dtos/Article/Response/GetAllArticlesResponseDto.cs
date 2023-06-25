namespace ScienceArchive.Application.Dtos.Article.Response;

/// <summary>
/// Response contract of getting all articles
/// </summary>
/// <param name="Articles">All existing articles</param>
public record GetAllArticlesResponseDto(List<ArticleDto> Articles);