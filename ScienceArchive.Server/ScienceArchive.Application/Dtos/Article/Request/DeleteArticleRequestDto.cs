namespace ScienceArchive.Application.Dtos.Article.Request;

/// <summary>
/// Request contract to delete article
/// </summary>
/// <param name="Id">ID of the article to delete</param>
public record DeleteArticleRequestDto(string Id);