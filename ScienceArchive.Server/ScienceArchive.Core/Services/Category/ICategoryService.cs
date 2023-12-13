using ScienceArchive.Core.Domain.Aggregates.Category;
using ScienceArchive.Core.Domain.Aggregates.Category.ValueObjects;
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
	/// Get category by ID
	/// </summary>
	/// <param name="contract">Contract to get category by ID</param>
	/// <returns>Found category or null</returns>
	Task<Category?> GetById(GetCategoryByIdContract contract);

	/// <summary>
	/// Get subcategory by ID
	/// </summary>
	/// <param name="contract">Contract to get subcategory by ID</param>
	/// <returns>Found subcategory or null</returns>
	Task<Category?> GetSubcategoryById(GetSubcategoryByIdContract contract);
	
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