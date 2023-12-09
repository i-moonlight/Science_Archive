using ScienceArchive.Core.Domain.Aggregates.Article;
using ScienceArchive.Core.Domain.Aggregates.Article.ValueObjects;
using ScienceArchive.Core.Services;
using ScienceArchive.Core.Services.ArticleContracts;

namespace ScienceArchive.BusinessLogic.Services;

internal class ArticleService : BaseService, IArticleService
{
    public ArticleService(IServiceProvider serviceProvider) : base(serviceProvider) { }

    /// <inheritdoc/>
    public async Task<Article?> GetVerifiedById(GetVerifiedArticleByIdContract contract)
    {
        return await ExecuteUseCase<Article?, GetVerifiedArticleByIdContract>(contract);
    }

    /// <inheritdoc/>
    public async Task<Article?> GetById(GetArticleByIdContract contract)
    {
        return await ExecuteUseCase<Article?, GetArticleByIdContract>(contract);
    }

    /// <inheritdoc/>
    public async Task<List<Article>> GetByAuthorId(GetArticlesByAuthorIdContract contract)
    {
        return await ExecuteUseCase<List<Article>, GetArticlesByAuthorIdContract>(contract);
    }

    /// <inheritdoc/>
    public async Task<List<Article>> GetVerifiedByAuthorId(GetVerifiedArticlesByAuthorIdContract contract)
    {
        return await ExecuteUseCase<List<Article>, GetVerifiedArticlesByAuthorIdContract>(contract);
    }

    /// <inheritdoc/>
    public async Task<List<Article>> GetVerifiedByCategoryId(GetVerifiedArticlesByCategoryIdContract contract)
    {
        return await ExecuteUseCase<List<Article>, GetVerifiedArticlesByCategoryIdContract>(contract);
    }

    /// <inheritdoc/>
    public async Task<List<Article>> GetAllVerified(GetAllVerifiedArticlesContract contract)
    {
        return await ExecuteUseCase<List<Article>, GetAllVerifiedArticlesContract>(contract);
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