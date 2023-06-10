using System;
using ScienceArchive.Application.Dtos.Article;

namespace ScienceArchive.Application.Dtos.Article.Request
{
    /// <summary>
    /// Request contract to create article
    /// </summary>
    /// <param name="Article">Article to create</param>
    public record CreateArticleRequestDto(ArticleDto Article);
}

