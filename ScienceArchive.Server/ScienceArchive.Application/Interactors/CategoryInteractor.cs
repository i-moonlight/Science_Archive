using ScienceArchive.Application.Dtos.Category;
using ScienceArchive.Application.Dtos.Category.Request;
using ScienceArchive.Application.Dtos.Category.Response;
using ScienceArchive.Application.Interfaces;
using ScienceArchive.Application.Interfaces.Interactors;
using ScienceArchive.Core.Domain.Aggregates.Category;
using ScienceArchive.Core.Services;
using ScienceArchive.Core.Services.CategoryContracts;

namespace ScienceArchive.Application.Interactors;

internal class CategoryInteractor : ICategoryInteractor
{
	private readonly ICategoryService _categoryService;
	private readonly IApplicationMapper<Category, CategoryDto> _categoryMapper;
	
	public CategoryInteractor(ICategoryService categoryService, IApplicationMapper<Category, CategoryDto> categoryMapper)
	{
		_categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
		_categoryMapper = categoryMapper ?? throw new ArgumentNullException(nameof(categoryMapper));
	}
	
	public async Task<GetAllCategoriesResponseDto> GetAllCategories(GetAllCategoriesRequestDto dto)
	{
		var emptyContract = new GetAllCategoriesContract();
		var categories = await _categoryService.GetAll(emptyContract);
		var categoriesDtos = categories.Select(c => _categoryMapper.MapToDto(c)).ToList();

		return new GetAllCategoriesResponseDto(categoriesDtos);
	}
}