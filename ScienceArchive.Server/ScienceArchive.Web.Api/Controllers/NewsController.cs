using Microsoft.AspNetCore.Mvc;
using ScienceArchive.Application.Dtos.News.Request;
using ScienceArchive.Application.Interfaces.Interactors;
using ScienceArchive.Web.Api.Responses;

namespace ScienceArchive.Web.Api.Controllers;

[Route("api/news")]
public class NewsController : Controller
{
    private readonly INewsInteractor _newsInteractor;

    public NewsController(INewsInteractor newsInteractor)
    {
        _newsInteractor = newsInteractor ?? throw new ArgumentNullException(nameof(newsInteractor));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var dto = new GetNewsByIdRequestDto(id);
        var result = await _newsInteractor.GetNewsById(dto);
        var response = new SuccessResponse(result);

        return Json(response);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var emptyRequest = new GetAllNewsRequestDto();

        var result = await _newsInteractor.GetAllNews(emptyRequest);
        var response = new SuccessResponse(result);
        
        return Json(response);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateNewsRequestDto dto)
    {
        var result = await _newsInteractor.CreateNews(dto);
        var response = new SuccessResponse(result);

        return Json(response);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update([FromBody] UpdateNewsRequestDto dto)
    {
        var result = await _newsInteractor.UpdateNews(dto);
        var response = new SuccessResponse(result);

        return Json(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var dto = new DeleteNewsRequestDto(id);

        var result = await _newsInteractor.DeleteNews(dto);
        var response = new SuccessResponse(result);

        return Json(response);
    }
}