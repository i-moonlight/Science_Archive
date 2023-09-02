using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Domain.Aggregates.Article.ValueObjects;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.ArticleContracts;

namespace ScienceArchive.BusinessLogic.ArticleUseCases;

internal class DeleteArticleUseCase : IUseCase<ArticleId, DeleteArticleContract>
{
    private readonly IArticleRepository _articleRepository;

    public DeleteArticleUseCase(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository ?? throw new ArgumentNullException(nameof(articleRepository));
    }

    public async Task<ArticleId> Execute(DeleteArticleContract contract)
    {
        return await _articleRepository.Delete(contract.ArticleId);
    }
}