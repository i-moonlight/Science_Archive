using System;
using ScienceArchive.Core.Dtos.Article;

namespace ScienceArchive.Core.Dtos.ArticleResponse
{
    /// <summary>
    /// Response contract of getting all articles
    /// </summary>
    /// <param name="Articles">All existing articles</param>
    public record GetAllArticlesResponseDto(List<ArticleDto> Articles);
}

