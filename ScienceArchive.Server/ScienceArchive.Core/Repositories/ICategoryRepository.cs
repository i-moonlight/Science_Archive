using ScienceArchive.Core.Domain.Aggregates.Category;
using ScienceArchive.Core.Domain.Aggregates.Category.ValueObjects;
using ScienceArchive.Core.Repositories.Common;

namespace ScienceArchive.Core.Repositories;

/// <summary>
/// Contains methods for working with
/// category entity through external storages
/// </summary>
public interface ICategoryRepository : ICrudRepository<CategoryId, Category>
{
	/// <summary>
	/// Create subcategory in category
	/// </summary>
	/// <param name="categoryId">Category ID where to create subcategory</param>
	/// <param name="subcategory">Subcategory to create</param>
	/// <returns>Created subcategory</returns>
	Task<Category> CreateSubcategory(CategoryId categoryId, Category subcategory);
	
	/// <summary>
	/// Update existing subcategory
	/// </summary>
	/// <param name="subcategoryId">Subcategory ID to update</param>
	/// <param name="subcategory">New subcategory value</param>
	/// <returns>Updated subcategory</returns>
	Task<Category> UpdateSubcategory(CategoryId subcategoryId, Category subcategory);
	
	/// <summary>
	/// Delete subcategory by its ID
	/// </summary>
	/// <param name="subcategoryId"></param>
	/// <returns>Deleted subcategory ID</returns>
	Task<CategoryId> DeleteSubcategory(CategoryId subcategoryId);
}