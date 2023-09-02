using ScienceArchive.Core.Domain.Aggregates.News;
using ScienceArchive.Core.Domain.Aggregates.News.ValueObjects;
using ScienceArchive.Core.Domain.Aggregates.User.ValueObjects;
using ScienceArchive.Infrastructure.Persistence.Interfaces;
using ScienceArchive.Infrastructure.Persistence.PostgreSql.Models;

namespace ScienceArchive.Infrastructure.PostgreSql.PersistenceMappers;

public class NewsMapper : IPersistenceMapper<News, NewsModel>
{
	public NewsModel MapToModel(News entity)
	{
		return new()
		{
			Id = entity.Id.Value,
			Title = entity.Title,
			Body = entity.Body,
			AuthorId = entity.Metadata.AuthorId.Value,
			CreationDate = entity.Metadata.CreationDate,
			LastUpdatedDate = entity.Metadata.LastUpdatedDate
		};
	}

	public News MapToEntity(NewsModel model)
	{
		var newsId = NewsId.CreateFromGuid(model.Id);
		
		return new(newsId)
		{
			Body = model.Body,
			Title = model.Title,
			Metadata = new NewsMetadata
			{
				AuthorId = UserId.CreateFromGuid(model.AuthorId),
				CreationDate = model.CreationDate,
				LastUpdatedDate = model.LastUpdatedDate
			}
		};
	}
}