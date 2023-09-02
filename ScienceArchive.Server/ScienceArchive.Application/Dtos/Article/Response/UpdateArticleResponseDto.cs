namespace ScienceArchive.Application.Dtos.Article.Response;

/// <summary>
/// Response contract of article update
/// </summary>
/// <param name="Article">Updated article</param>
public record UpdateArticleResponseDto(ArticleDto Article);