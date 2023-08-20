using Microsoft.AspNetCore.Mvc;
using ScienceArchive.Application.Dtos.Article.Request;
using ScienceArchive.Application.Interfaces.Interactors;
using ScienceArchive.Web.Api.Responses;

namespace ScienceArchive.Web.Api.Controllers;

[Route("api/articles")]
public class ArticleController : Controller
{
    private readonly IArticleInteractor _articleInteractor;

    public ArticleController(IArticleInteractor articleInteractor)
    {
        _articleInteractor = articleInteractor ?? throw new ArgumentNullException(nameof(articleInteractor));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var emptyRequest = new GetAllArticlesRequestDto();

        var result = await _articleInteractor.GetAllArticles(emptyRequest);
        var response = new SuccessResponse(result);
        
        return Json(response);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateArticleRequestDto dto)
    {
        var result = await _articleInteractor.CreateArticle(dto);
        var response = new SuccessResponse(result);
        
        return Json(response);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update([FromBody] UpdateArticleRequestDto dto)
    {
        var result = await _articleInteractor.UpdateArticle(dto);
        var response = new SuccessResponse(result);

        return Json(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var dto = new DeleteArticleRequestDto(id);
        var result = await _articleInteractor.DeleteArticle(dto);
        var response = new SuccessResponse(result);
        
        return Json(response);
    }
}