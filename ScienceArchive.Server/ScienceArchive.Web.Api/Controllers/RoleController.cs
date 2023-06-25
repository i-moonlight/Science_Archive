using Microsoft.AspNetCore.Mvc;
using ScienceArchive.Application.Dtos.Role.Request;
using ScienceArchive.Application.Interfaces.Interactors;
using ScienceArchive.Web.Api.Responses;

namespace ScienceArchive.Web.Api.Controllers;

[Route("api/roles")]
public class RoleController : Controller
{
    private readonly IRoleInteractor _roleInteractor;

    public RoleController(IRoleInteractor roleInteractor)
    {
        _roleInteractor = roleInteractor ?? throw new ArgumentNullException(nameof(roleInteractor));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var emptyRequest = new GetAllRolesRequestDto();

        try
        {
            var result = await _roleInteractor.GetAllRoles(emptyRequest);
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