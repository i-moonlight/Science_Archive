using System;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Dtos.News;
using ScienceArchive.Core.Interfaces.Mappers;

namespace ScienceArchive.Application.Mappers
{
    public class NewsMapper : IMapper<News, NewsDto>
    {
        public NewsDto MapToDto(News entity)
        {
            return new()
            {
                Id = entity.Id,
                Body = entity.Body,
                CreationDate = entity.CreationDate,
                Title = entity.Title
            };
        }

        public News MapToEntity(NewsDto dto, Guid? id = null)
        {
            return new(id)
            {
                Body = dto.Body,
                CreationDate = dto.CreationDate,
                Title = dto.Title
            };
        }
    }
}

