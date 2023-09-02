using ScienceArchive.Application.Dtos.Category.Request;
using ScienceArchive.Application.Dtos.Category.Response;

namespace ScienceArchive.Application.Interfaces.Interactors;

/// <summary>
/// Application category interactor
/// </summary>
public interface ICategoryInteractor
{
	/// <summary>
	/// Get all categories
	/// </summary>
	/// <param name="dto">DTO to get all categories</param>
	/// <returns>All existing categories</returns>
	Task<GetAllCategoriesResponseDto> GetAllCategories(GetAllCategoriesRequestDto dto);
}