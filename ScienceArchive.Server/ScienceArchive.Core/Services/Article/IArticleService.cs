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
    /// Get article with specified ID
    /// </summary>
    /// <param name="contract">Contract to get article with specified id</param>
    /// <returns>Found article if it exists, otherwise, null</returns>
    Task<Article?> GetById(GetArticleByIdContract contract);

    /// <summary>
    /// Get articles by category ID
    /// </summary>
    /// <param name="contract">Contract to get articles by category ID</param>
    /// <returns>Articles with specified category ID</returns>
    Task<List<Article>> GetByCategoryId(GetArticlesByCategoryIdContract contract);
    
    /// <summary>
    /// Get all articles
    /// </summary>
    /// <param name="contract">Contract to get all articles</param>
    /// <returns>Articles</returns>
    Task<List<Article>> GetAll(GetAllArticlesContract contract);

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