using System;
using ScienceArchive.Core.Dtos.Article;

namespace ScienceArchive.Core.Dtos.Article.Response
{
    /// <summary>
    /// Response contract of article update
    /// </summary>
    /// <param name="Article">Updated article</param>
    public record UpdateArticleResponseDto(ArticleDto Article);
}

