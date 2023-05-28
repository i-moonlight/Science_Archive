using System;
namespace ScienceArchive.Core.Dtos.Article.Request
{
    /// <summary>
    /// Request contract to delete article
    /// </summary>
    /// <param name="id">ID of the article to delete</param>
    public record DeleteArticleRequestDto(Guid Id);
}

