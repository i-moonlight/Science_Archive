using System;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Services;
using ScienceArchive.Core.Services.ArticleContracts;

namespace ScienceArchive.BusinessLogic.Services
{
    public class ArticleService : BaseService, IArticleService
    {
        public ArticleService(IServiceProvider serviceProvider) : base(serviceProvider) { }

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
        public async Task<Guid> Delete(DeleteArticleContract contract)
        {
            return await ExecuteUseCase<Guid, DeleteArticleContract>(contract);
        }
    }
}

