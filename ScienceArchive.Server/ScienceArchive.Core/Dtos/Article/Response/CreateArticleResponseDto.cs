﻿using System;
using ScienceArchive.Core.Dtos.Article;

namespace ScienceArchive.Core.Dtos.Article.Response
{
    /// <summary>
    /// Response contract of article creation
    /// </summary>
    /// <param name="Article">Created article</param>
    public record CreateArticleResponseDto(ArticleDto Article);
}
