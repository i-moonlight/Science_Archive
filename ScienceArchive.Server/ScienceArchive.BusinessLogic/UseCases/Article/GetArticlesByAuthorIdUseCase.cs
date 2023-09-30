using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Domain.Aggregates.Article;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.ArticleContracts;

namespace ScienceArchive.BusinessLogic.ArticleUseCases;

public class GetArticlesByAuthorIdUseCase : IUseCase<List<Article>, GetArticlesByAuthorIdContract>
{
	private readonly IArticleRepository _articleRepository;
	
	public GetArticlesByAuthorIdUseCase(IArticleRepository articleRepository)
	{
		_articleRepository = articleRepository ?? throw new ArgumentNullException(nameof(articleRepository));
	}
	
	public async Task<List<Article>> Execute(GetArticlesByAuthorIdContract contract)
	{
		return await _articleRepository.GetByAuthorId(contract.AuthorId);
	}
}