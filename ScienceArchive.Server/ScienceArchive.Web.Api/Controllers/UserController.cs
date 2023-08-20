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
        
        var result = await _userInteractor.GetAllUsers(emptyRequest);
        var response = new SuccessResponse(result);

        return Json(response);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update([FromBody] UpdateUserRequestDto dto)
    {
        var result = await _userInteractor.UpdateUser(dto);
        var response = new SuccessResponse(result);

        return Json(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var dto = new DeleteUserRequestDto(id);

        var result = await _userInteractor.DeleteUser(dto);
        var response = new SuccessResponse(result);

        return Json(response);
    }
}