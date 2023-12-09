using ScienceArchive.Core.Domain.Aggregates.User.ValueObjects;

namespace ScienceArchive.Core.Services.ArticleContracts;

/// <summary>
/// Contract to get verified articles by user ID
/// </summary>
/// <param name="AuthorId">Author ID</param>
public record GetVerifiedArticlesByAuthorIdContract(UserId AuthorId);