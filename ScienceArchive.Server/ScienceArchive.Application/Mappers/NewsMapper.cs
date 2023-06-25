using ScienceArchive.Application.Dtos.News;
using ScienceArchive.Application.Interfaces;
using ScienceArchive.Core.Domain.Entities;

namespace ScienceArchive.Application.Mappers;

public class NewsMapper : IApplicationMapper<News, NewsDto>
{
    public NewsDto MapToDto(News entity)
    {
        return new()
        {
            Id = entity.Id.ToString(),
            Body = entity.Body,
            CreationDate = entity.CreationDate,
            Title = entity.Title
        };
    }

    public News MapToEntity(NewsDto model, string? id = null)
    {
        Guid? newsId = id is not null
            ? new Guid(id)
            : null;

        return new(newsId)
        {
            Body = model.Body,
            CreationDate = model.CreationDate,
            Title = model.Title
        };
    }
}