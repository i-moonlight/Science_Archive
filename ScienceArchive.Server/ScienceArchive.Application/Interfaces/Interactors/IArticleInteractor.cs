using ScienceArchive.Application.Dtos.Article.Request;
using ScienceArchive.Application.Dtos.Article.Response;

namespace ScienceArchive.Application.Interfaces.Interactors;

/// <summary>
/// Application article interactor
/// </summary>
public interface IArticleInteractor
{
    /// <summary>
    /// Get all articles
    /// </summary>
    /// <param name="dto">DTO contract to get all articles</param>
    /// <returns>Response DTO</returns>
    Task<GetAllArticlesResponseDto> GetAllArticles(GetAllArticlesRequestDto dto);

    /// <summary>
    /// Get articles with specified author ID
    /// </summary>
    /// <param name="dto">DTO contract to get articles by author ID</param>
    /// <returns>Response DTO</returns>
    Task<GetArticlesByAuthorIdResponseDto> GetArticlesByAuthorId(GetArticlesByAuthorIdRequestDto dto);
    
    /// <summary>
    /// Get article by ID
    /// </summary>
    /// <param name="dto">DTO contract to get article by ID</param>
    /// <returns>Response DTO</returns>
    Task<GetArticleByIdResponseDto> GetArticleById(GetArticleByIdRequestDto dto);

    /// <summary>
    /// Get articles by category ID
    /// </summary>
    /// <param name="dto">DTO contract to get articles by category ID</param>
    /// <returns>Response DTO</returns>
    Task<GetArticlesByCategoryIdResponseDto> GetArticlesByCategoryId(GetArticlesByCategoryIdRequestDto dto);

    /// <summary>
    /// Create new article
    /// </summary>
    /// <param name="dto">DTO contract to create new article</param>
    /// <returns>Response DTO</returns>
    Task<CreateArticleResponseDto> CreateArticle(CreateArticleRequestDto dto);

    /// <summary>
    /// Update existing article
    /// </summary>
    /// <param name="dto">DTO contract to update article</param>
    /// <returns>Response DTO</returns>
    Task<UpdateArticleResponseDto> UpdateArticle(UpdateArticleRequestDto dto);

    /// <summary>
    /// Delete existing article
    /// </summary>
    /// <param name="dto">DTO contract to delete article</param>
    /// <returns>Response DTO</returns>
    Task<DeleteArticleResponseDto> DeleteArticle(DeleteArticleRequestDto dto);
}