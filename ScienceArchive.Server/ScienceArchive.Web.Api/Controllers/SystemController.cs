using Microsoft.AspNetCore.Mvc;
using ScienceArchive.Application.Dtos.System.Request;
using ScienceArchive.Application.Interfaces.Interactors;
using ScienceArchive.Web.Api.Responses;

namespace ScienceArchive.Web.Api.Controllers;

[Route("api/system")]
public class SystemController : Controller
{
    private readonly ISystemInteractor _systemInteractor;

    public SystemController(ISystemInteractor systemInteractor)
    {
        _systemInteractor = systemInteractor ?? throw new ArgumentNullException(nameof(systemInteractor));
    }

    [HttpGet("check-status")]
    public async Task<IActionResult> CheckStatus()
    {
        var emptyRequest = new CheckSystemStatusRequestDto();
        
        var result = await _systemInteractor.CheckSystemStatus(emptyRequest);
        var response = new SuccessResponse(result);

        return Json(response);
    }
}