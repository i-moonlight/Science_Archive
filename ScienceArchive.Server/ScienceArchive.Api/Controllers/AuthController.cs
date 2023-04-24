using Microsoft.AspNetCore.Mvc;
using ScienceArchive.Core.Interfaces.Services;
using ScienceArchive.Api.Responses;
using ScienceArchive.Core.Dtos.UserRequest;
using ScienceArchive.Api.Auth;

namespace ScienceArchive.Api.Controllers
{
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly AuthManager _authManager;

        public AuthController(IUserService userService, IConfiguration configuration, AuthManager authManager)
        {
            _userService = userService;
            _configuration = configuration;
            _authManager = authManager;
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] AuthorizeUserRequestDto request)
        {
            try
            {
                var result = await _userService.Authorize(request);

                if (!result.UserExist || result.User is null)
                {
                    var errorResponse = new ErrorResponse("This user does not exist!");
                    return Json(errorResponse);
                }

                var token = _authManager.GenerateToken(result.User);

                var response = new SuccessResponse(new
                {
                    token = token,
                    user = result.User,
                });

                return Json(response);
            }
            catch (Exception e)
            {
                var response = new ErrorResponse(e.Message);
                return Json(response);
            }
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] CreateUserRequestDto request)
        {
            try
            {
                var result = await _userService.Create(request);
                var response = new SuccessResponse(result);

                return Json(response);
            }
            catch (Exception e)
            {
                var response = new ErrorResponse(e.Message);
                return Json(response);
            }
        }
    }
}
