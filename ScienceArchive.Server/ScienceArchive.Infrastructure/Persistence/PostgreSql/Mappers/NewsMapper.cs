using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Infrastructure.Persistence.Interfaces;
using ScienceArchive.Infrastructure.Persistence.PostgreSql.Models;

namespace ScienceArchive.Infrastructure.Persistence.PostgreSql.Mappers;

public class NewsMapper : IPersistenceMapper<News, NewsModel>
{
	public NewsModel MapToModel(News entity)
	{
		return new()
		{
			Id = entity.Id,
			Title = entity.Title,
			Body = entity.Body,
			AuthorId = entity.AuthorId,
			CreationDate = entity.CreationDate
		};
	}

	public News MapToEntity(NewsModel model, Guid? id = null)
	{
		return new(id)
		{
			Body = model.Body,
			Title = model.Title,
			AuthorId = model.AuthorId,
			CreationDate = model.CreationDate
		};
	}
}