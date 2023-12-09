using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Domain.Aggregates.Article;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.ArticleContracts;

namespace ScienceArchive.BusinessLogic.ArticleUseCases;

public class GetVerifiedArticlesByAuthorIdUseCase : IUseCase<List<Article>, GetVerifiedArticlesByAuthorIdContract>
{
	private readonly IArticleRepository _articleRepository;
	
	public GetVerifiedArticlesByAuthorIdUseCase(IArticleRepository articleRepository)
	{
		_articleRepository = articleRepository ?? throw new ArgumentNullException(nameof(articleRepository));
	}
	
	public async Task<List<Article>> Execute(GetVerifiedArticlesByAuthorIdContract contract)
	{
		return await _articleRepository.GetVerifiedByAuthorId(contract.AuthorId);
	}
}