using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScienceArchive.Application.Dtos.Article.Request;
using ScienceArchive.Application.Interfaces.Interactors;
using ScienceArchive.Web.Api.Responses;
using ScienceArchive.Web.Api.Utils;

namespace ScienceArchive.Web.Api.Controllers;

[Route("api/articles")]
public class ArticleController : ControllerBase
{
    private readonly IArticleInteractor _articleInteractor;

    public ArticleController(IArticleInteractor articleInteractor)
    {
        _articleInteractor = articleInteractor ?? throw new ArgumentNullException(nameof(articleInteractor));
    }
    
    [HttpGet("by-category/{categoryId}")]
    public async Task<Response> GetByCategoryId(string categoryId)
    {
        if (string.IsNullOrWhiteSpace(categoryId))
        {
            throw new BadHttpRequestException("Category ID was not presented");
        }
        
        var dto = new GetArticlesByCategoryIdRequestDto(categoryId);
        var result = await _articleInteractor.GetArticlesByCategoryId(dto);
        return new SuccessResponse(result);
    }
    
    [Authorize]
    [HttpGet("my-articles")]
    public async Task<Response> GetUserArticles()
    {
        var userId = HttpContext.GetUserIdFromToken();

        if (string.IsNullOrWhiteSpace(userId))
        {
            throw new BadHttpRequestException("Cannot get user ID", 401);
        }

        var result = await _articleInteractor.GetArticlesByAuthorId(new (userId));
        return new SuccessResponse(result);
    }
    
    [HttpGet("by-author/{authorId}")]
    public async Task<Response> GetVerifiedByAuthorId(string? authorId)
    {
        if (string.IsNullOrWhiteSpace(authorId))
        {
            throw new BadHttpRequestException("Author ID was not presented");
        }

        var dto = new GetArticlesByAuthorIdRequestDto(authorId);
        var result = await _articleInteractor.GetArticlesByAuthorId(dto);
        return new SuccessResponse(result);
    }
    
    [HttpGet("{id}")]
    public async Task<Response> GetById(string? id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new BadHttpRequestException("ID was not presented");
        }
        
        var dto = new GetArticleByIdRequestDto(id);
        var result = await _articleInteractor.GetArticleById(dto);
        return new SuccessResponse(result);
    }

    [HttpGet]
    public async Task<Response> GetAll()
    {
        var emptyRequest = new GetAllArticlesRequestDto();

        var result = await _articleInteractor.GetAllArticles(emptyRequest);
        return new SuccessResponse(result);
    }
    
    [Authorize]
    [HttpPost("create")]
    public async Task<Response> Create([FromBody] CreateArticleRequestDto? dto)
    {
        if (dto is null)
        {
            throw new BadHttpRequestException("No data presented");
        }
        
        var result = await _articleInteractor.CreateArticle(dto);
        return new SuccessResponse(result);
    }
    
    [Authorize]
    [HttpPost("update")]
    public async Task<Response> Update([FromBody] UpdateArticleRequestDto? dto)
    {
        if (dto is null)
        {
            throw new BadHttpRequestException("No data presented");
        }
        
        var result = await _articleInteractor.UpdateArticle(dto);
        return new SuccessResponse(result);
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<Response> Delete(string? id)
    {
        if (id is null)
        {
            throw new BadHttpRequestException("No data presented");
        }
        
        var dto = new DeleteArticleRequestDto(id);
        var result = await _articleInteractor.DeleteArticle(dto);
        return new SuccessResponse(result);
    }
}