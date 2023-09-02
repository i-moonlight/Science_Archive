using ScienceArchive.Core.Domain.Aggregates.Category.ValueObjects;

namespace ScienceArchive.Core.Services.ArticleContracts;

/// <summary>
/// Contract to get articles by category ID
/// </summary>
/// <param name="CategoryId">Category ID</param>
public record GetArticlesByCategoryIdContract(CategoryId CategoryId);