using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Domain.Aggregates.Article;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.ArticleContracts;

namespace ScienceArchive.BusinessLogic.ArticleUseCases;

public class GetArticleByIdUseCase : IUseCase<Article?, GetArticleByIdContract>
{
	private readonly IArticleRepository _articleRepository;
	
	public GetArticleByIdUseCase(IArticleRepository articleRepository)
	{
		_articleRepository = articleRepository ?? throw new ArgumentNullException(nameof(articleRepository));
	}
	
	public async Task<Article?> Execute(GetArticleByIdContract contract)
	{
		return await _articleRepository.GetById(contract.Id);
	}
}