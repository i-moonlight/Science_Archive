using ScienceArchive.Application.Dtos.Article;
using ScienceArchive.Application.Interfaces;
using ScienceArchive.Core.Domain.Aggregates.Article;
using ScienceArchive.Core.Domain.Aggregates.Article.Enums;
using ScienceArchive.Core.Domain.Aggregates.Article.ValueObjects;
using ScienceArchive.Core.Domain.Aggregates.Category.ValueObjects;
using ScienceArchive.Core.Domain.Aggregates.User.ValueObjects;

namespace ScienceArchive.Application.Mappers;

internal class ArticleMapper : IApplicationMapper<Article, ArticleDto>
{
    public ArticleDto MapToDto(Article entity)
    {
        var authorsIds = entity.AuthorsIds.Select(a => a.ToString()).ToList();
        var documentsPaths = entity.Documents.Select(d => d.DocumentPath).ToList();
        
        return new()
        {
            Id = entity.Id.ToString(),
            CategoryId = entity.CategoryId.ToString(),
            Status = (int)entity.Status,
            CreationDate = entity.CreationDate,
            Title = entity.Title,
            Description = entity.Description,
            AuthorsIds = authorsIds,
            DocumentsPaths = documentsPaths
        };
    }

    public Article MapToEntity(ArticleDto dto)
    {
        var articleId = string.IsNullOrWhiteSpace(dto.Id)
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
            Status = (ArticleStatus)dto.Status,
            CreationDate = dto.CreationDate.GetValueOrDefault(DateTime.Now),
            Title = dto.Title,
            Description = dto.Description,
            AuthorsIds = authorsIds,
            Documents = documents
        };
    }
}