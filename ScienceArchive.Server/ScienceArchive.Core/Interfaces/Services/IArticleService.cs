using System;
using ScienceArchive.Core.Dtos.ArticleRequest;
using ScienceArchive.Core.Dtos.ArticleResponse;

namespace ScienceArchive.Core.Interfaces.Services
{
    /// <summary>
    /// Base functionality of article service
    /// </summary>
    public interface IArticleService
    {
        /// <summary>
        /// Get all articles
        /// </summary>
        /// <param name="contract">Request contract to get all articles</param>
        /// <returns>Get all articles response contract</returns>
        Task<GetAllArticlesResponseDto> GetAll(GetAllArticlesRequestDto contract);

        /// <summary>
        /// Create article
        /// </summary>
        /// <param name="contract">Request contract to create article</param>
        /// <returns>Create article response contract</returns>
        Task<CreateArticleResponseDto> Create(CreateArticleRequestDto contract);

        /// <summary>
        /// Update article
        /// </summary>
        /// <param name="contract">Request contract to update article</param>
        /// <returns>Update article response contract</returns>
        Task<UpdateArticleResponseDto> Update(UpdateArticleRequestDto contract);

        /// <summary>
        /// Delete article
        /// </summary>
        /// <param name="contract">Request contract to delete article</param>
        /// <returns>Delete article response contract</returns>
        Task<DeleteArticleResponseDto> Delete(DeleteArticleRequestDto contract);
    }
}

