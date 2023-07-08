using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Infrastructure.Persistence.Interfaces;
using ScienceArchive.Infrastructure.Persistence.PostgreSql.Models;

namespace ScienceArchive.Infrastructure.Persistence.PostgreSql.Mappers;

public class ArticleMapper : IPersistenceMapper<Article, ArticleModel>
{
	public ArticleModel MapToModel(Article entity)
	{
		return new()
		{
			Id = entity.Id,
			Title = entity.Title,
			AuthorId = entity.AuthorId,
			CreationDate = entity.CreationDate,
			Description = entity.Description,
			DocumentPath = entity.DocumentPath
		};
	}

	public Article MapToEntity(ArticleModel model, Guid? id = null)
	{
		return new(id)
		{
			Title = model.Title,
			AuthorId = model.AuthorId,
			CreationDate = model.CreationDate,
			Description = model.Description,
			DocumentPath = model.DocumentPath
		};
	}
}