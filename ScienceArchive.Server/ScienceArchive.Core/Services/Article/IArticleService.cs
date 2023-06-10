using System;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Services.ArticleContracts;

namespace ScienceArchive.Core.Services
{
    /// <summary>
    /// Functionality of article service
    /// </summary>
    public interface IArticleService
    {
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
        Task<Guid> Delete(DeleteArticleContract contract);
    }
}

