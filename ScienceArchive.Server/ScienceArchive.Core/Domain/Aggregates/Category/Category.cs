using ScienceArchive.Core.Domain.Aggregates.Category.ValueObjects;
using ScienceArchive.Core.Domain.Common;

namespace ScienceArchive.Core.Domain.Aggregates.Category;

/// <summary>
/// Represents category of articles
/// </summary>
public class Category : AggregateRoot<CategoryId>
{
	public Category(CategoryId id) : base(id)
	{
	}
	
	/// <summary>
	/// Name of category
	/// </summary>
	public required string Name { get; set; }
	
	/// <summary>
	/// Subcategories of a category
	/// </summary>
	public List<Category>? Subcategories { get; set; }
}