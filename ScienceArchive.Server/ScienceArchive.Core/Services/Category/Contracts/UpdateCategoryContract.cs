using ScienceArchive.Core.Domain.Aggregates.Category;
using ScienceArchive.Core.Domain.Aggregates.Category.ValueObjects;

namespace ScienceArchive.Core.Services.CategoryContracts;

public record UpdateCategoryContract(CategoryId Id, Category Category);