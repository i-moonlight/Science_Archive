using ScienceArchive.Core.Domain.Aggregates.Article;
using ScienceArchive.Core.Domain.Aggregates.Article.ValueObjects;
using ScienceArchive.Core.Domain.Aggregates.Category.ValueObjects;
using ScienceArchive.Core.Domain.Aggregates.User.ValueObjects;
using ScienceArchive.Core.Repositories.Common;

namespace ScienceArchive.Core.Repositories;

/// <summary>
/// Article repository functionality
/// </summary>
public interface IArticleRepository : ICrudRepository<ArticleId, Article>
{
	/// <summary>
	/// Get articles by category ID
	/// </summary>
	/// <param name="categoryId">Category ID</param>
	/// <returns>All articles of specified category</returns>
	Task<List<Article>> GetByCategoryId(CategoryId categoryId);

	/// <summary>
	/// Get articles by author ID
	/// </summary>
	/// <param name="userId">Author ID</param>
	/// <returns>All articles of specified author</returns>
	Task<List<Article>> GetByAuthorId(UserId userId);
}