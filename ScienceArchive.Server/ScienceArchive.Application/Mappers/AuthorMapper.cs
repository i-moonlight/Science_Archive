using ScienceArchive.Application.Dtos;
using ScienceArchive.Application.Interfaces;
using ScienceArchive.Core.Domain.Aggregates.Article.ValueObjects;
using ScienceArchive.Core.Domain.Aggregates.Role.ValueObjects;
using ScienceArchive.Core.Domain.Aggregates.User;
using ScienceArchive.Core.Domain.Aggregates.User.ValueObjects;

namespace ScienceArchive.Application.Mappers;

internal class AuthorMapper : IApplicationMapper<Author, AuthorDto>
{
	public AuthorDto MapToDto(Author author)
	{
		var articlesIds = author.ArticlesIds.Select(r => r.ToString()).ToList();
        
		return new AuthorDto()
		{
			Id = author.Id.ToString(),
			Name = author.Name,
			Description = author.Description,
			ArticlesIds = articlesIds
		};
	}

	public Author MapToEntity(AuthorDto dto)
	{
		var authorId = UserId.CreateFromString(dto.Id);
		var articlesIds = dto.ArticlesIds.Select(ArticleId.CreateFromString).ToList();
        
		return new Author(authorId)
		{
			Name = dto.Name,
			Description = dto.Description,
			ArticlesIds = articlesIds
		};
	}
}