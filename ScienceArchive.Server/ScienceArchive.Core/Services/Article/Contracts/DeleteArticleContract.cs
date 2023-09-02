using ScienceArchive.Core.Domain.Aggregates.Article.ValueObjects;

namespace ScienceArchive.Core.Services.ArticleContracts;

/// <summary>
/// Contract to delete article
/// </summary>
/// <param name="ArticleId">Article ID to delete</param>
public record DeleteArticleContract(ArticleId ArticleId);