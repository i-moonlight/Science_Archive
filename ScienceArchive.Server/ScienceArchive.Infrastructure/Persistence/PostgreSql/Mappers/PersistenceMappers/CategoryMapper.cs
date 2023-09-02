using ScienceArchive.Core.Domain.Aggregates.Category;
using ScienceArchive.Core.Domain.Aggregates.Category.ValueObjects;
using ScienceArchive.Infrastructure.Persistence.Interfaces;
using ScienceArchive.Infrastructure.Persistence.PostgreSql.Models;

namespace ScienceArchive.Infrastructure.PostgreSql.PersistenceMappers;

public class CategoryMapper : IPersistenceMapper<Category, CategoryModel>
{
	private readonly IPersistenceMapper<Category, SubcategoryModel> _subcategoryMapper;
	
	public CategoryMapper(IPersistenceMapper<Category, SubcategoryModel> subcategoryMapper)
	{
		_subcategoryMapper = subcategoryMapper ?? throw new ArgumentNullException(nameof(subcategoryMapper));
	}
	
	public CategoryModel MapToModel(Category entity)
	{
		var subcategories = entity.Subcategories?.Select(_subcategoryMapper.MapToModel).ToList();

		return new()
		{
			Id = entity.Id.Value,
			Name = entity.Name,
			Subcategories = subcategories
		};
	}

	public Category MapToEntity(CategoryModel model)
	{
		var categoryId = CategoryId.CreateFromGuid(model.Id);
		var subcategories = model.Subcategories?.Select(_subcategoryMapper.MapToEntity).ToList();

		return new(categoryId)
		{
			Name = model.Name,
			Subcategories = subcategories
		};
	}
}