using Microsoft.AspNetCore.Mvc;
using ScienceArchive.Application.Dtos.Auth.Request;
using ScienceArchive.Application.Dtos.User.Request;
using ScienceArchive.Application.Interfaces.Interactors;
using ScienceArchive.Web.Api.Auth;
using ScienceArchive.Web.Api.Responses;

namespace ScienceArchive.Web.Api.Controllers
{
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly AuthManager _authManager;
        private readonly IAuthInteractor _authInteractor;
        private readonly IConfiguration _configuration;

        public AuthController(
            AuthManager authManager,
            IAuthInteractor authInteractor,
            IConfiguration configuration)
        {
            if (authManager is null)
            {
                throw new ArgumentNullException(nameof(authManager));
            }

            if (authInteractor is null)
            {
                throw new ArgumentNullException(nameof(authInteractor));
            }

            if (configuration is null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            _authInteractor = authInteractor;
            _configuration = configuration;
            _authManager = authManager;
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn([FromBody] LoginRequestDto request)
        {
            try
            {
                var result = await _authInteractor.Login(request);
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

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequestDto request)
        {
            try
            {
                var result = await _authInteractor.SignUp(request);
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
