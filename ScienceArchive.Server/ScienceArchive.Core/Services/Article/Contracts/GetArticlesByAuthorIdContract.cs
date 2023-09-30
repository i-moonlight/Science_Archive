using ScienceArchive.Core.Domain.Aggregates.User.ValueObjects;

namespace ScienceArchive.Core.Services.ArticleContracts;

/// <summary>
/// Contract to get articles by user id
/// </summary>
/// <param name="AuthorId">Author ID</param>
public record GetArticlesByAuthorIdContract(UserId AuthorId);