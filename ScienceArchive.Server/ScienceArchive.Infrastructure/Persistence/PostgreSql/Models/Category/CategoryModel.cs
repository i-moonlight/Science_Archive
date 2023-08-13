namespace ScienceArchive.Infrastructure.Persistence.PostgreSql.Models;

public class CategoryModel
{
	public required Guid Id { get; set; }
	public required string Name { get; set; }
	public List<CategoryModel>? Subcategories { get; set; }
}