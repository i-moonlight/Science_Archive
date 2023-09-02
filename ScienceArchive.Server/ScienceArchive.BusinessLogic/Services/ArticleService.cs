using ScienceArchive.Core.Domain.Aggregates.Article;
using ScienceArchive.Core.Domain.Aggregates.Article.ValueObjects;
using ScienceArchive.Core.Services;
using ScienceArchive.Core.Services.ArticleContracts;

namespace ScienceArchive.BusinessLogic.Services;

internal class ArticleService : BaseService, IArticleService
{
    public ArticleService(IServiceProvider serviceProvider) : base(serviceProvider) { }

    /// <inheritdoc/>
    public async Task<Article?> GetById(GetArticleByIdContract contract)
    {
        return await ExecuteUseCase<Article?, GetArticleByIdContract>(contract);
    }

    public async Task<List<Article>> GetByCategoryId(GetArticlesByCategoryIdContract contract)
    {
        return await ExecuteUseCase<List<Article>, GetArticlesByCategoryIdContract>(contract);
    }

    /// <inheritdoc/>
    public async Task<List<Article>> GetAll(GetAllArticlesContract contract)
    {
        return await ExecuteUseCase<List<Article>, GetAllArticlesContract>(contract);
    }

    /// <inheritdoc/>
    public async Task<Article> Create(CreateArticleContract contract)
    {
        return await ExecuteUseCase<Article, CreateArticleContract>(contract);
    }

    /// <inheritdoc/>
    public async Task<Article> Update(UpdateArticleContract contract)
    {
        return await ExecuteUseCase<Article, UpdateArticleContract>(contract);
    }

    /// <inheritdoc/>
    public async Task<ArticleId> Delete(DeleteArticleContract contract)
    {
        return await ExecuteUseCase<ArticleId, DeleteArticleContract>(contract);
    }
}