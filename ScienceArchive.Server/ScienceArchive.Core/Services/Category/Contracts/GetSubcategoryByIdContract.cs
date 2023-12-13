using ScienceArchive.Core.Domain.Aggregates.Category.ValueObjects;

namespace ScienceArchive.Core.Services.CategoryContracts;

/// <summary>
/// Contract to get subcategory by ID
/// </summary>
/// <param name="subcategoryId">Subcategory ID</param>
public record GetSubcategoryByIdContract(CategoryId SubcategoryId);