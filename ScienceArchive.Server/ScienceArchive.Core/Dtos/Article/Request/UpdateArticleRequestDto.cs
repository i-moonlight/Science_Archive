using System;
using ScienceArchive.Core.Dtos.Article;

namespace ScienceArchive.Core.Dtos.Article.Request
{
    /// <summary>
    /// Request contract to update an article
    /// </summary>
    /// <param name="Id">ID of article to update</param>
    /// <param name="NewArticle">New article data</param>
    public record UpdateArticleRequestDto(Guid Id, ArticleDto NewArticle);
}

