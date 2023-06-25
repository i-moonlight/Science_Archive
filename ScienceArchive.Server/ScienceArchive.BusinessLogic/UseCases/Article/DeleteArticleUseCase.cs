using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.ArticleContracts;

namespace ScienceArchive.BusinessLogic.ArticleUseCases;

public class DeleteArticleUseCase : IUseCase<Guid, DeleteArticleContract>
{
    private readonly IArticleRepository _articleRepository;

    public DeleteArticleUseCase(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository ?? throw new ArgumentNullException(nameof(articleRepository));
    }

    public async Task<Guid> Execute(DeleteArticleContract contract)
    {
        return await _articleRepository.Delete(contract.ArticleId);
    }
}