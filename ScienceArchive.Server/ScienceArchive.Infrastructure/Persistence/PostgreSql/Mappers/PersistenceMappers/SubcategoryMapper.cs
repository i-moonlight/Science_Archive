using ScienceArchive.Core.Domain.Aggregates.Category;
using ScienceArchive.Core.Domain.Aggregates.Category.ValueObjects;
using ScienceArchive.Infrastructure.Persistence.Interfaces;
using ScienceArchive.Infrastructure.Persistence.PostgreSql.Models;

namespace ScienceArchive.Infrastructure.PostgreSql.PersistenceMappers;

public class SubcategoryMapper : IPersistenceMapper<Category, SubcategoryModel>
{
	public SubcategoryModel MapToModel(Category entity)
	{
		return new()
		{
			Id = entity.Id.Value,
			Name = entity.Name,
		};
	}

	public Category MapToEntity(SubcategoryModel model)
	{
		var categoryId = CategoryId.CreateFromGuid(model.Id);

		return new(categoryId)
		{
			Name = model.Name,
			Subcategories = null
		};
	}
}