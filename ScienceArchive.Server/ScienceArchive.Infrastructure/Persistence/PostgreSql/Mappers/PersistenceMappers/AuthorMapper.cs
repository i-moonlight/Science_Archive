using ScienceArchive.Core.Domain.Aggregates.Article.ValueObjects;
using ScienceArchive.Core.Domain.Aggregates.Role.ValueObjects;
using ScienceArchive.Core.Domain.Aggregates.User;
using ScienceArchive.Core.Domain.Aggregates.User.ValueObjects;
using ScienceArchive.Infrastructure.Persistence.Interfaces;
using ScienceArchive.Infrastructure.Persistence.PostgreSql.Models;

namespace ScienceArchive.Infrastructure.PostgreSql.PersistenceMappers;

internal class AuthorMapper : IPersistenceMapper<Author, AuthorModel>
{
	public AuthorModel MapToModel(Author author)
	{
		var articlesIds = author.ArticlesIds.Select(a => a.Value).ToList();
        
		return new()
		{
			Id = author.Id.Value,
			Name = author.Name,
			ArticlesIds = articlesIds
		};
	}

	public Author MapToEntity(AuthorModel model)
	{
		var authorId = UserId.CreateFromGuid(model.Id);
		var articlesIds = model.ArticlesIds.Select(ArticleId.CreateFromGuid).ToList();
        
		return new(authorId)
		{
			Name = model.Name,
			Description = null,
			ArticlesIds = articlesIds
		};
	}
}