using System;
using ScienceArchive.Core.Dtos.Article;

namespace ScienceArchive.Core.Dtos.ArticleRequest
{
    /// <summary>
    /// Request contract to update an article
    /// </summary>
    /// <param name="id">ID of article to update</param>
    /// <param name="newArticle">New article data</param>
    public record UpdateArticleRequestDto(Guid id, ArticleDto newArticle);
}

