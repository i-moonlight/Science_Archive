using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScienceArchive.Api.Responses;
using ScienceArchive.Application.Dtos.News.Request;
using ScienceArchive.Application.Interfaces.Interactors;

namespace ScienceArchive.Api.Controllers
{
    [Route("api/news")]
    public class NewsController : Controller
    {
        private readonly INewsInteractor _newsInteractor;

        public NewsController(INewsInteractor newsInteractor)
        {
            if (newsInteractor is null)
            {
                throw new ArgumentNullException(nameof(newsInteractor));
            }

            _newsInteractor = newsInteractor;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var emptyRequest = new GetAllNewsRequestDto();

            try
            {
                var result = await _newsInteractor.GetAllNews(emptyRequest);
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

