﻿namespace ScienceArchive.Application.Dtos.Article.Request;

/// <summary>
/// Request contract to update an article
/// </summary>
/// <param name="Id">ID of article to update</param>
/// <param name="Article">New article data</param>
public record UpdateArticleRequestDto(string Id, ArticleDto Article);