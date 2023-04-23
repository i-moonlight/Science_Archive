using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScienceArchive.Api.Responses;
using ScienceArchive.Application.Services;
using ScienceArchive.Core.Interfaces.Services;

namespace ScienceArchive.Api.Controllers
{
    [Route("api/system")]
    public class SystemController : Controller
    {
        private readonly ISystemService _systemService;

        public SystemController(ISystemService systemService)
        {
            _systemService = systemService;
        }

        [HttpGet("check-status")]
        public async Task<IActionResult> CheckStatus()
        {
            try
            {
                var result = await _systemService.CheckSystemStatus();
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

