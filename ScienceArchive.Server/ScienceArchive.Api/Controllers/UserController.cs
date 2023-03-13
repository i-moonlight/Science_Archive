using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScienceArchive.Api.Responses;
using ScienceArchive.Core.Interfaces.Services;

namespace ScienceArchive.Api.Controllers
{
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _userService.GetAll();
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
}

