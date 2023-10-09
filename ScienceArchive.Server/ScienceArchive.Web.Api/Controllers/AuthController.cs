using Microsoft.AspNetCore.Mvc;
using ScienceArchive.Application.Dtos.Auth.Request;
using ScienceArchive.Application.Interfaces.Interactors;
using ScienceArchive.Web.Api.Auth;
using ScienceArchive.Web.Api.Responses;

namespace ScienceArchive.Web.Api.Controllers;

[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AuthManager _authManager;
    private readonly IAuthInteractor _authInteractor;

    public AuthController(AuthManager authManager, IAuthInteractor authInteractor)
    {
        _authInteractor = authInteractor ?? throw new ArgumentNullException(nameof(authInteractor));
        _authManager = authManager ?? throw new ArgumentNullException(nameof(authManager));
    }

    [HttpPost("check-admin")]
    public async Task<Response> CheckAdmin([FromBody] CheckUserClaimsRequestDto request)
    {
        request.RequiredClaims = new List<string> { "ADMIN" };
        var result = await _authInteractor.CheckUserClaims(request);
        
        return new SuccessResponse(new
        {
            isAdmin = result.Success
        });
    }
    
    [HttpPost("sign-in")]
    public async Task<Response> SignIn([FromBody] LoginRequestDto request)
    {
        var result = await _authInteractor.Login(request);
        var token = _authManager.GenerateToken(result.User);

        return new SuccessResponse(new
        {
            user = result.User,
            token,
        });
    }

    [HttpPost("sign-up")]
    public async Task<Response> SignUp([FromBody] SignUpRequestDto request)
    {
        var result = await _authInteractor.SignUp(request);
        return new SuccessResponse(result);
    }
}