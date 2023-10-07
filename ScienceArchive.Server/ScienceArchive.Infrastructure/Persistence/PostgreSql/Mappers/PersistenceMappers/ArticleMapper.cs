using ScienceArchive.Core.Domain.Aggregates.Article;
using ScienceArchive.Core.Domain.Aggregates.Article.ValueObjects;
using ScienceArchive.Core.Domain.Aggregates.Category.ValueObjects;
using ScienceArchive.Core.Domain.Aggregates.User.ValueObjects;
using ScienceArchive.Infrastructure.Persistence.Interfaces;
using ScienceArchive.Infrastructure.Persistence.PostgreSql.Models;

namespace ScienceArchive.Infrastructure.PostgreSql.PersistenceMappers;

internal class ArticleMapper : IPersistenceMapper<Article, ArticleModel>
{
	public ArticleModel MapToModel(Article entity)
	{
		var authorsIds = entity.AuthorsIds.Select(a => a.Value).ToList();
		var documents = entity.Documents.Select(d => new ArticleDocumentModel
		{
			DocumentPath = d.DocumentPath
		}).ToList();
		
		return new()
		{
			Id = entity.Id.Value,
			CategoryId = entity.CategoryId.Value,
			Title = entity.Title,
			CreationDate = entity.CreationDate,
			Description = entity.Description,
			AuthorsIds = authorsIds,
			Documents = documents
		};
	}

	public Article MapToEntity(ArticleModel model)
	{
		var articleId = ArticleId.CreateFromGuid(model.Id);
		var authorsIds = model.AuthorsIds.Select(UserId.CreateFromGuid).ToList();
		var documents = model.Documents.Select(d => new ArticleDocument
		{
			DocumentPath = d.DocumentPath
		}).ToList();
		
		return new(articleId)
		{
			CategoryId = CategoryId.CreateFromGuid(model.CategoryId),
			Title = model.Title,
			CreationDate = model.CreationDate,
			Description = model.Description,
			AuthorsIds = authorsIds,
			Documents = documents
		};
	}
}