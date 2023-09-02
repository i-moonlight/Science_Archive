using ScienceArchive.Core.Domain.Aggregates.Category;
using ScienceArchive.Core.Services.CategoryContracts;

namespace ScienceArchive.Core.Services;

/// <summary>
/// Contains a set of business-logic methods
/// to interact with categories
/// </summary>
public interface ICategoryService
{
	/// <summary>
	/// Get all existing categories 
	/// </summary>
	/// <param name="contract">Contract to get all categories</param>
	/// <returns>All existing categories</returns>
	Task<List<Category>> GetAll(GetAllCategoriesContract contract);
	
	/// <summary>
	/// Create new category
	/// </summary>
	/// <param name="contract">Contract to create new category</param>
	/// <returns>Created category</returns>
	Task<Category> Create(CreateCategoryContract contract);
	
	/// <summary>
	/// Update existing category
	/// </summary>
	/// <param name="contract">Contract to update category</param>
	/// <returns>Updated category</returns>
	Task<Category> Update(UpdateCategoryContract contract);
}