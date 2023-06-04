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

        public ArticleDto MapToModel(Article entity)
        {
            return new()
            {
                Id = entity.Id,
                Author = _userMapper.MapToModel(entity.Author),
                CreationDate = entity.CreationDate,
                Title = entity.Title,
                Description = entity.Description,
                DocumentPath = entity.DocumentPath
            };
        }

        public Article MapToEntity(ArticleDto model, Guid? id = null)
        {
            return new(id)
            {
                Author = _userMapper.MapToEntity(model.Author),
                CreationDate = model.CreationDate,
                Title = model.Title,
                Description = model.Description,
                DocumentPath = model.DocumentPath
            };
        }
    }
}

