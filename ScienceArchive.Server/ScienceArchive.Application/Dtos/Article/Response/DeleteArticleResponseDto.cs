﻿namespace ScienceArchive.Application.Dtos.Article.Response;

/// <summary>
/// Response contract of article deletion
/// </summary>
/// <param name="Id">ID of the deleted article</param>
public record DeleteArticleResponseDto(string Id);