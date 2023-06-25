using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Services;
using ScienceArchive.Core.Services.NewsContracts;

namespace ScienceArchive.BusinessLogic.Services;

public class NewsService : BaseService, INewsService
{
    public NewsService(IServiceProvider serviceProvider) : base(serviceProvider) { }

    /// <inheritdoc/>
    public async Task<News> Create(CreateNewsContract contract)
    {
        return await ExecuteUseCase<News, CreateNewsContract>(contract);
    }

    /// <inheritdoc/>
    public async Task<Guid> Delete(DeleteNewsContract contract)
    {
        return await ExecuteUseCase<Guid, DeleteNewsContract>(contract);
    }

    /// <inheritdoc/>
    public async Task<List<News>> GetAll(GetAllNewsContract contract)
    {
        return await ExecuteUseCase<List<News>, GetAllNewsContract>(contract);
    }

    /// <inheritdoc/>
    public async Task<News> Update(UpdateNewsContract contract)
    {
        return await ExecuteUseCase<News, UpdateNewsContract>(contract);
    }
}