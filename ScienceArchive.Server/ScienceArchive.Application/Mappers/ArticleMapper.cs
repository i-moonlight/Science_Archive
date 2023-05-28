using System;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Dtos;
using ScienceArchive.Core.Dtos.Article;
using ScienceArchive.Core.Interfaces.Mappers;

namespace ScienceArchive.Application.Mappers
{
    public class ArticleMapper : IMapper<Article, ArticleDto>
    {
        private readonly IMapper<User, UserDto> _userMapper;

        public ArticleMapper(IMapper<User, UserDto> userMapper)
        {
            if (userMapper is null)
            {
                throw new ArgumentNullException(nameof(userMapper));
            }

            _userMapper = userMapper;
        }

        public ArticleDto MapToDto(Article entity)
        {
            return new()
            {
                Id = entity.Id,
                Author = _userMapper.MapToDto(entity.Author),
                CreationDate = entity.CreationDate,
                Title = entity.Title,
                Description = entity.Description,
                DocumentPath = entity.DocumentPath
            };
        }

        public Article MapToEntity(ArticleDto dto, Guid? id = null)
        {
            return new(id)
            {
                Author = _userMapper.MapToEntity(dto.Author),
                CreationDate = dto.CreationDate,
                Title = dto.Title,
                Description = dto.Description,
                DocumentPath = dto.DocumentPath
            };
        }
    }
}

