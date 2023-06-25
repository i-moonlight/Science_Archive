using ScienceArchive.Application.Dtos;
using ScienceArchive.Application.Dtos.Article;
using ScienceArchive.Application.Interfaces;
using ScienceArchive.Core.Domain.Entities;

namespace ScienceArchive.Application.Mappers;

public class ArticleMapper : IApplicationMapper<Article, ArticleDto>
{
    private readonly IApplicationMapper<User, UserDto> _userMapper;

    public ArticleMapper(IApplicationMapper<User, UserDto> userMapper)
    {
        _userMapper = userMapper ?? throw new ArgumentNullException(nameof(userMapper));
    }

    public ArticleDto MapToDto(Article entity)
    {
        return new()
        {
            Id = entity.Id.ToString(),
            Author = _userMapper.MapToDto(entity.Author),
            CreationDate = entity.CreationDate,
            Title = entity.Title,
            Description = entity.Description,
            DocumentPath = entity.DocumentPath
        };
    }

    public Article MapToEntity(ArticleDto dto, string? id = null)
    {
        Guid? articleId = id is not null
            ? new Guid(id)
            : null;

        return new(articleId)
        {
            Author = _userMapper.MapToEntity(dto.Author),
            CreationDate = dto.CreationDate,
            Title = dto.Title,
            Description = dto.Description,
            DocumentPath = dto.DocumentPath
        };
    }
}