using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ScienceArchive.Api.Controllers
{
    [Route("api/auth")]
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Json(new
            {
                success = true,
            });
        }
    }
}

