using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Domain.Aggregates.Article;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.ArticleContracts;

namespace ScienceArchive.BusinessLogic.ArticleUseCases;

public class GetVerifiedArticlesBySubcategoryIdUseCase : IUseCase<List<Article>, GetVerifiedArticlesBySubcategoryIdContract>
{
	private readonly IArticleRepository _articleRepository;
	
	public GetVerifiedArticlesBySubcategoryIdUseCase(IArticleRepository articleRepository)
	{
		_articleRepository = articleRepository ?? throw new ArgumentNullException(nameof(articleRepository));
	}
	
	public async Task<List<Article>> Execute(GetVerifiedArticlesBySubcategoryIdContract contract)
	{
		return await _articleRepository.GetVerifiedByCategoryId(contract.CategoryId);
	}
}