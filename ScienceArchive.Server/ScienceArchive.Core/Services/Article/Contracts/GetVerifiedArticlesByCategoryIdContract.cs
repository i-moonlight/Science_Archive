using ScienceArchive.Core.Domain.Aggregates.Category.ValueObjects;

namespace ScienceArchive.Core.Services.ArticleContracts;

/// <summary>
/// Contract to get verified articles by category ID
/// </summary>
/// <param name="CategoryId">Category ID</param>
public record GetVerifiedArticlesByCategoryIdContract(CategoryId CategoryId);