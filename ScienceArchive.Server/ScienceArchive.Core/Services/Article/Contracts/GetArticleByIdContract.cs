using ScienceArchive.Core.Domain.Aggregates.Article.ValueObjects;

namespace ScienceArchive.Core.Services.ArticleContracts;

/// <summary>
/// Contract to get article with specified ID
/// </summary>
/// <param name="Id">ID of the article to find</param>
public record GetArticleByIdContract(ArticleId Id);