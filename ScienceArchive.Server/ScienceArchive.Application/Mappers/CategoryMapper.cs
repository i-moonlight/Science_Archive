using ScienceArchive.Application.Dtos.Category;
using ScienceArchive.Application.Interfaces;
using ScienceArchive.Core.Domain.Aggregates.Category;
using ScienceArchive.Core.Domain.Aggregates.Category.ValueObjects;

namespace ScienceArchive.Application.Mappers;

public class CategoryMapper : IApplicationMapper<Category, CategoryDto>
{
	public CategoryDto MapToDto(Category entity)
	{
		var subcategories = entity.Subcategories?.Select(MapToDto).ToList();

		return new()
		{
			Id = entity.Id.ToString(),
			Name = entity.Name,
			Subcategories = subcategories
		};
	}

	public Category MapToEntity(CategoryDto dto)
	{
		var id = dto.Id is not null
			? CategoryId.CreateFromString(dto.Id)
			: CategoryId.CreateNew();
		
		var subcategories = dto.Subcategories?.Select(MapToEntity).ToList();

		return new(id)
		{
			Name = dto.Name,
			Subcategories = subcategories
		};
	}
}