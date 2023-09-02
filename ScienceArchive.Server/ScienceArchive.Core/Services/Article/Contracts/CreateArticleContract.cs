using ScienceArchive.Core.Domain.Aggregates.Article;

namespace ScienceArchive.Core.Services.ArticleContracts;

/// <summary>
/// Contract to create new article
/// </summary>
/// <param name="Article">Article to create</param>
public record CreateArticleContract(Article Article);