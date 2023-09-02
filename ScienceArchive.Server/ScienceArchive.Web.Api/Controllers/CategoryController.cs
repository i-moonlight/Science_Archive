using Microsoft.AspNetCore.Mvc;
using ScienceArchive.Application.Dtos.Category.Request;
using ScienceArchive.Application.Interfaces.Interactors;
using ScienceArchive.Web.Api.Responses;

namespace ScienceArchive.Web.Api.Controllers;

[Route("api/categories")]
public class CategoryController : Controller
{
	private readonly ICategoryInteractor _categoryInteractor;
	
	public CategoryController(ICategoryInteractor categoryInteractor)
	{
		_categoryInteractor = categoryInteractor ?? throw new ArgumentNullException(nameof(categoryInteractor));
	}
	
	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var emptyDto = new GetAllCategoriesRequestDto();
		var result = await _categoryInteractor.GetAllCategories(emptyDto);
		var response = new SuccessResponse(result);
		
		return Json(response);
	} 
}