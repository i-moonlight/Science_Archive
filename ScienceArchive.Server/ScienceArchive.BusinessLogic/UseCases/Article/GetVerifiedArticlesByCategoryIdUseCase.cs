using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Domain.Aggregates.Article;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.ArticleContracts;

namespace ScienceArchive.BusinessLogic.ArticleUseCases;

public class GetVerifiedArticlesByCategoryIdUseCase : IUseCase<List<Article>, GetVerifiedArticlesByCategoryIdContract>
{
	private readonly IArticleRepository _articleRepository;
	
	public GetVerifiedArticlesByCategoryIdUseCase(IArticleRepository articleRepository)
	{
		_articleRepository = articleRepository ?? throw new ArgumentNullException(nameof(articleRepository));
	}
	
	public async Task<List<Article>> Execute(GetVerifiedArticlesByCategoryIdContract contract)
	{
		return await _articleRepository.GetVerifiedByCategoryId(contract.CategoryId);
	}
}