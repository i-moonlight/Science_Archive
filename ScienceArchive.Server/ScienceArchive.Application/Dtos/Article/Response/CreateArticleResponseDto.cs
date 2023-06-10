using System;
using ScienceArchive.Application.Dtos.Article;

namespace ScienceArchive.Application.Dtos.Article.Response
{
    /// <summary>
    /// Response contract of article creation
    /// </summary>
    /// <param name="Article">Created article</param>
    public record CreateArticleResponseDto(ArticleDto Article);
}

