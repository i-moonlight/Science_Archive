using ScienceArchive.Core.Domain.Aggregates.Category.ValueObjects;

namespace ScienceArchive.Core.Services.CategoryContracts;

/// <summary>
/// Contract to get category by ID
/// </summary>
/// <param name="Id">ID of category to find</param>
public record GetCategoryByIdContract(CategoryId Id);