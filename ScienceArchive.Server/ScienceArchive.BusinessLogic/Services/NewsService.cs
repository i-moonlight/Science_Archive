using ScienceArchive.Core.Domain.Aggregates.News;
using ScienceArchive.Core.Domain.Aggregates.News.ValueObjects;
using ScienceArchive.Core.Services;
using ScienceArchive.Core.Services.NewsContracts;

namespace ScienceArchive.BusinessLogic.Services;

internal class NewsService : BaseService, INewsService
{
    public NewsService(IServiceProvider serviceProvider) : base(serviceProvider) { }

    /// <inheritdoc/>
    public async Task<News?> GetById(GetNewsByIdContract contract)
    {
        return await ExecuteUseCase<News?, GetNewsByIdContract>(contract);
    }
    
    /// <inheritdoc/>
    public async Task<List<News>> GetAll(GetAllNewsContract contract)
    {
        return await ExecuteUseCase<List<News>, GetAllNewsContract>(contract);
    }
    
    /// <inheritdoc/>
    public async Task<News> Create(CreateNewsContract contract)
    {
        return await ExecuteUseCase<News, CreateNewsContract>(contract);
    }

    /// <inheritdoc/>
    public async Task<NewsId> Delete(DeleteNewsContract contract)
    {
        return await ExecuteUseCase<NewsId, DeleteNewsContract>(contract);
    }


    /// <inheritdoc/>
    public async Task<News> Update(UpdateNewsContract contract)
    {
        return await ExecuteUseCase<News, UpdateNewsContract>(contract);
    }
}