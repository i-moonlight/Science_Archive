using ScienceArchive.Core.Domain.Aggregates.Article;
using ScienceArchive.Core.Domain.Aggregates.Article.ValueObjects;
using ScienceArchive.Core.Services.ArticleContracts;

namespace ScienceArchive.Core.Services;

/// <summary>
/// Contains a set of business-logic methods
/// to interact with articles
/// </summary>
public interface IArticleService
{
    /// <summary>
    /// Get verified article with specified ID
    /// </summary>
    /// <param name="contract">Contract to get verified article with specified ID</param>
    /// <returns>Found article if it exists, otherwise, null</returns>
    Task<Article?> GetVerifiedById(GetVerifiedArticleByIdContract contract);

    /// <summary>
    /// Get article with specified ID
    /// </summary>
    /// <param name="contract">Contract to get article with specified ID</param>
    /// <returns>Found article if it exists, otherwise, null</returns>
    Task<Article?> GetById(GetArticleByIdContract contract);
    
    /// <summary>
    /// Get articles by author ID
    /// </summary>
    /// <param name="contract">Contract to get articles by author ID</param>
    /// <returns>Articles with specified author ID</returns>
    Task<List<Article>> GetByAuthorId(GetArticlesByAuthorIdContract contract);
    
    /// <summary>
    /// Get all verified articles by author ID
    /// </summary>
    /// <param name="contract">Contract to get verified articles by author ID</param>
    /// <returns>Verified articles of specified author</returns>
    Task<List<Article>> GetVerifiedByAuthorId(GetVerifiedArticlesByAuthorIdContract contract);

    /// <summary>
    /// Get articles by category ID
    /// </summary>
    /// <param name="contract">Contract to get articles by category ID</param>
    /// <returns>Articles with specified category ID</returns>
    Task<List<Article>> GetVerifiedByCategoryId(GetVerifiedArticlesByCategoryIdContract contract);
    
    /// <summary>
    /// Get all articles
    /// </summary>
    /// <param name="contract">Contract to get all articles</param>
    /// <returns>Articles</returns>
    Task<List<Article>> GetAllVerified(GetAllVerifiedArticlesContract contract);

    /// <summary>
    /// Create article
    /// </summary>
    /// <param name="contract">Contract to create article</param>
    /// <returns>Created article</returns>
    Task<Article> Create(CreateArticleContract contract);

    /// <summary>
    /// Update article
    /// </summary>
    /// <param name="contract">Contract to update article</param>
    /// <returns>Updated article</returns>
    Task<Article> Update(UpdateArticleContract contract);

    /// <summary>
    /// Delete article
    /// </summary>
    /// <param name="contract">Contract to delete article</param>
    /// <returns>Deleted article ID</returns>
    Task<ArticleId> Delete(DeleteArticleContract contract);
}