using Microsoft.AspNetCore.Mvc;
using ScienceArchive.Application.Dtos.User.Request;
using ScienceArchive.Application.Interfaces.Interactors;
using ScienceArchive.Web.Api.Responses;

namespace ScienceArchive.Web.Api.Controllers;

[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserInteractor _userInteractor;

    public UserController(IUserInteractor userInteractor)
    {
        _userInteractor = userInteractor ?? throw new ArgumentNullException(nameof(userInteractor));
    }

    [HttpGet("{id}")]
    public async Task<Response> GetById(string id)
    {
        var dto = new GetUserByIdRequestDto(id);
        var result = await _userInteractor.GetUserById(dto);
        return new SuccessResponse(result);
    }

    [HttpGet("get-authors")]
    public async Task<Response> GetAllAuthors()
    {
        var emptyRequest = new GetAllAuthorsRequestDto();

        var result = await _userInteractor.GetAllAuthors(emptyRequest);
        return new SuccessResponse(result);
    }
    
    [HttpGet]
    public async Task<Response> GetAll()
    {
        var emptyRequest = new GetAllUsersRequestDto();
        
        var result = await _userInteractor.GetAllUsers(emptyRequest);
        return new SuccessResponse(result);
    }

    [HttpPost("update")]
    public async Task<Response> Update([FromBody] UpdateUserRequestDto dto)
    {
        var result = await _userInteractor.UpdateUser(dto);
        return new SuccessResponse(result);
    }

    [HttpDelete("{id}")]
    public async Task<Response> Delete(string id)
    {
        var dto = new DeleteUserRequestDto(id);

        var result = await _userInteractor.DeleteUser(dto);
        return new SuccessResponse(result);;
    }
}