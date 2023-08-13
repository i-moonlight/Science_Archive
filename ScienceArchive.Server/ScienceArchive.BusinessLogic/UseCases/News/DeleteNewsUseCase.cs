using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Domain.Aggregates.News.ValueObjects;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.NewsContracts;

namespace ScienceArchive.BusinessLogic.NewsUseCases;

internal class DeleteNewsUseCase : IUseCase<NewsId, DeleteNewsContract>
{
    private readonly INewsRepository _newsRepository;

    public DeleteNewsUseCase(INewsRepository newsRepository)
    {
        _newsRepository = newsRepository ?? throw new ArgumentNullException(nameof(newsRepository));
    }

    public async Task<NewsId> Execute(DeleteNewsContract contract)
    {
        return await _newsRepository.Delete(contract.Id);
    }
}