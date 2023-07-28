using ScienceArchive.Core.Domain.Aggregates.Article;
using ScienceArchive.Core.Domain.Aggregates.Article.ValueObjects;

namespace ScienceArchive.Core.Services.ArticleContracts;

/// <summary>
/// Contract to update article
/// </summary>
/// <param name="Id">ID of the article to update</param>
/// <param name="Article">New article</param>
public record UpdateArticleContract(ArticleId Id, Article Article);