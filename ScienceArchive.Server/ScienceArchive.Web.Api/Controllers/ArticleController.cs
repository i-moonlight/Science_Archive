using Microsoft.AspNetCore.Mvc;
using ScienceArchive.Application.Dtos.Article.Request;
using ScienceArchive.Application.Interfaces.Interactors;
using ScienceArchive.Web.Api.Responses;

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
        if (categoryId is null)
        {
            throw new ArgumentNullException(nameof(categoryId));
        }
        
        var dto = new GetArticlesByCategoryIdRequestDto(categoryId);
        var result = await _articleInteractor.GetArticlesByCategoryId(dto);
        return new SuccessResponse(result);
    }
    
    [HttpGet("{id}")]
    public async Task<Response> GetById(string id)
    {
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

    [HttpPost("create")]
    public async Task<Response> Create([FromBody] CreateArticleRequestDto dto)
    {
        var result = await _articleInteractor.CreateArticle(dto);
        return new SuccessResponse(result);
    }

    [HttpPost("update")]
    public async Task<Response> Update([FromBody] UpdateArticleRequestDto dto)
    {
        var result = await _articleInteractor.UpdateArticle(dto);
        return new SuccessResponse(result);
    }

    [HttpDelete("{id}")]
    public async Task<Response> Delete(string id)
    {
        var dto = new DeleteArticleRequestDto(id);
        var result = await _articleInteractor.DeleteArticle(dto);
        return new SuccessResponse(result);
    }
}