using ScienceArchive.Application.Dtos.News;
using ScienceArchive.Application.Interfaces;
using ScienceArchive.Core.Domain.Aggregates.News;
using ScienceArchive.Core.Domain.Aggregates.News.ValueObjects;
using ScienceArchive.Core.Domain.Aggregates.User.ValueObjects;

namespace ScienceArchive.Application.Mappers;

public class NewsMapper : IApplicationMapper<News, NewsDto>
{
    public NewsDto MapToDto(News entity)
    {
        return new()
        {
            Id = entity.Id.ToString(),
            Body = entity.Body,
            Title = entity.Title,
            CreationDate = entity.Metadata.CreationDate,
            AuthorId = entity.Metadata.AuthorId.ToString(),
            LastUpdatedDate = entity.Metadata.LastUpdatedDate
        };
    }

    public News MapToEntity(NewsDto model)
    {
        var newsId = model.Id is not null
            ? NewsId.CreateFromString(model.Id)
            : NewsId.CreateNew();

        return new(newsId)
        {
            Body = model.Body,
            Title = model.Title,
            Metadata = new NewsMetadata
            {
                AuthorId = UserId.CreateFromString(model.AuthorId),
                CreationDate = model.CreationDate.GetValueOrDefault(DateTime.Now),
                LastUpdatedDate = model.LastUpdatedDate,
            }
        };
    }
}