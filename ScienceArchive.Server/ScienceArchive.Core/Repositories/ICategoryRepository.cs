using ScienceArchive.Core.Domain.Aggregates.Category;
using ScienceArchive.Core.Domain.Aggregates.Category.ValueObjects;
using ScienceArchive.Core.Repositories.Common;

namespace ScienceArchive.Core.Repositories;

/// <summary>
/// Contains methods for working with
/// category entity through external storages
/// </summary>
public interface ICategoryRepository : ICrudRepository<CategoryId, Category> { }