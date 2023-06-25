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