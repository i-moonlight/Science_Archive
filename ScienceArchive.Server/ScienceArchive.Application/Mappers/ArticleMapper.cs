﻿using ScienceArchive.Application.Dtos;
using ScienceArchive.Application.Dtos.Article;
using ScienceArchive.Application.Interfaces;
using ScienceArchive.Core.Domain.Aggregates.Article;
using ScienceArchive.Core.Domain.Aggregates.Article.ValueObjects;
using ScienceArchive.Core.Domain.Aggregates.Category.ValueObjects;
using ScienceArchive.Core.Domain.Aggregates.User;
using ScienceArchive.Core.Domain.Aggregates.User.ValueObjects;

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
        var authorsIds = entity.AuthorsIds.Select(a => a.ToString()).ToList();
        var documentsPaths = entity.Documents.Select(d => d.DocumentPath).ToList();
        
        return new()
        {
            Id = entity.Id.ToString(),
            CategoryId = entity.CategoryId.ToString(),
            CreationDate = entity.CreationDate,
            Title = entity.Title,
            Description = entity.Description,
            AuthorsIds = authorsIds,
            DocumentsPaths = documentsPaths
        };
    }

    public Article MapToEntity(ArticleDto dto)
    {
        var articleId = dto.Id is null 
            ? ArticleId.CreateNew()
            : ArticleId.CreateFromString(dto.Id);

        var authorsIds = dto.AuthorsIds.Select(UserId.CreateFromString).ToList();
        var documents = dto.DocumentsPaths
            .Select(d => new ArticleDocument
            {
                DocumentPath = d
            })
            .ToList();
        
        return new(articleId)
        {
            CategoryId = CategoryId.CreateFromString(dto.CategoryId),
            CreationDate = dto.CreationDate.GetValueOrDefault(DateTime.Now),
            Title = dto.Title,
            Description = dto.Description,
            AuthorsIds = authorsIds,
            Documents = documents
        };
    }
}