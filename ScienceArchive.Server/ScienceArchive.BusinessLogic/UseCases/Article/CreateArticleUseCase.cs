using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Domain.Aggregates.Article;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.ArticleContracts;

namespace ScienceArchive.BusinessLogic.ArticleUseCases;

internal class CreateArticleUseCase : IUseCase<Article, CreateArticleContract>
{
    private readonly IArticleRepository _articleRepository;

    public CreateArticleUseCase(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository ?? throw new ArgumentNullException(nameof(articleRepository));
    }

    public async Task<Article> Execute(CreateArticleContract contract)
    {
        return await _articleRepository.Create(contract.Article);
    }
}