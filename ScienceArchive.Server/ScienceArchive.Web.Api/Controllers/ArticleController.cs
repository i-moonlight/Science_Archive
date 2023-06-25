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

        try
        {
            var result = await _articleInteractor.GetAllArticles(emptyRequest);
            var response = new SuccessResponse(result);
            return Json(response);
        }
        catch (Exception ex)
        {
            var response = new ErrorResponse(ex.Message);
            return Json(response);
        }
    }
}