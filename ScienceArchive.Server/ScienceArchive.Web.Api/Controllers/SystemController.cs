using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScienceArchive.Application.Dtos.System.Request;
using ScienceArchive.Application.Interfaces.Interactors;
using ScienceArchive.Web.Api.Responses;

namespace ScienceArchive.Web.Api.Controllers
{
    [Route("api/system")]
    public class SystemController : Controller
    {
        private readonly ISystemInteractor _systemInteractor;

        public SystemController(ISystemInteractor systemInteractor)
        {
            if (systemInteractor is null)
            {
                throw new ArgumentNullException(nameof(systemInteractor));
            }

            _systemInteractor = systemInteractor;
        }

        [HttpGet("check-status")]
        public async Task<IActionResult> CheckStatus()
        {
            var emptyRequest = new CheckSystemStatusRequestDto();

            try
            {
                var result = await _systemInteractor.CheckSystemStatus(emptyRequest);
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

