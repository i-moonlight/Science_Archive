using Microsoft.AspNetCore.Mvc;
using ScienceArchive.Application.Dtos.User.Request;
using ScienceArchive.Application.Interfaces.Interactors;
using ScienceArchive.Web.Api.Responses;

namespace ScienceArchive.Web.Api.Controllers;

[Route("api/users")]
public class UserController : Controller
{
    private readonly IUserInteractor _userInteractor;

    public UserController(IUserInteractor userInteractor)
    {
        _userInteractor = userInteractor ?? throw new ArgumentNullException(nameof(userInteractor));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var emptyRequest = new GetAllUsersRequestDto();

        try
        {
            var result = await _userInteractor.GetAllUsers(emptyRequest);
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