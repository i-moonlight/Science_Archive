using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using ScienceArchive.Api.Responses;
using ScienceArchive.Application.Dtos.Role.Request;
using ScienceArchive.Application.Interfaces.Interactors;

namespace ScienceArchive.Api.Controllers
{
    [Route("api/roles")]
    public class RoleController : Controller
    {
        private readonly IRoleInteractor _roleInteractor;

        public RoleController(IRoleInteractor roleInteractor)
        {
            if (roleInteractor is null)
            {
                throw new ArgumentNullException(nameof(roleInteractor));
            }

            _roleInteractor = roleInteractor;
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
}

