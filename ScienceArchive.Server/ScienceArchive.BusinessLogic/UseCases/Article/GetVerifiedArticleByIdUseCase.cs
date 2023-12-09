using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Domain.Aggregates.Article;
using ScienceArchive.Core.Domain.Aggregates.Article.Enums;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.ArticleContracts;

namespace ScienceArchive.BusinessLogic.ArticleUseCases;

public class GetVerifiedArticleByIdUseCase : IUseCase<Article?, GetVerifiedArticleByIdContract>
{
	private readonly IArticleRepository _articleRepository;
	
	public GetVerifiedArticleByIdUseCase(IArticleRepository articleRepository)
	{
		_articleRepository = articleRepository ?? throw new ArgumentNullException(nameof(articleRepository));
	}
	
	public async Task<Article?> Execute(GetVerifiedArticleByIdContract contract)
	{
		var foundArticle = await _articleRepository.GetById(contract.Id);

		if (foundArticle is null)
		{
			return null;
		}

		return foundArticle.Status != ArticleStatus.Verified ? null : foundArticle;
	}
}