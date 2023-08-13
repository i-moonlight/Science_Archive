namespace ScienceArchive.Application.Dtos.Category;

public record CategoryDto
{
	/// <summary>
	/// Identifier of the category
	/// </summary>
	public string? Id { get; set; }
	
	/// <summary>
	/// Name of category
	/// </summary>
	public required string Name { get; set; }
	
	/// <summary>
	/// Subcategories of a category
	/// </summary>
	public List<CategoryDto>? Subcategories { get; set; }
}