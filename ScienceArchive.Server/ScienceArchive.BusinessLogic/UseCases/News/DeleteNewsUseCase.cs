using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.NewsContracts;

namespace ScienceArchive.BusinessLogic.NewsUseCases;

public class DeleteNewsUseCase : IUseCase<Guid, DeleteNewsContract>
{
    private readonly INewsRepository _newsRepository;

    public DeleteNewsUseCase(INewsRepository newsRepository)
    {
        _newsRepository = newsRepository ?? throw new ArgumentNullException(nameof(newsRepository));
    }

    public async Task<Guid> Execute(DeleteNewsContract contract)
    {
        return await _newsRepository.Delete(contract.NewsId);
    }
}