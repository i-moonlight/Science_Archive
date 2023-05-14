﻿using System;
using ScienceArchive.Core.Dtos.Article;

namespace ScienceArchive.Core.Dtos.ArticleRequest
{
    /// <summary>
    /// Request contract to create article
    /// </summary>
    /// <param name="Article">Article to create</param>
    public record CreateArticleRequestDto(ArticleDto Article);
}

