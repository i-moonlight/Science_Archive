using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Domain.Aggregates.Article;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.ArticleContracts;

namespace ScienceArchive.BusinessLogic.ArticleUseCases;

internal class UpdateArticleUseCase : IUseCase<Article, UpdateArticleContract>
{
    private readonly IArticleRepository _articleRepository;

    public UpdateArticleUseCase(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository ?? throw new ArgumentNullException(nameof(articleRepository));
    }

    public async Task<Article> Execute(UpdateArticleContract contract)
    {
        return await _articleRepository.Update(contract.Id, contract.Article);
    }
}