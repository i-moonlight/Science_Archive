using System;
using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.ArticleContracts;

namespace ScienceArchive.BusinessLogic.ArticleUseCases
{
    public class UpdateArticleUseCase : IUseCase<Article, UpdateArticleContract>
    {
        private readonly IArticleRepository _articleRepository;

        public UpdateArticleUseCase(IArticleRepository articleRepository)
        {
            if (articleRepository is null)
            {
                throw new ArgumentNullException(nameof(articleRepository));
            }

            _articleRepository = articleRepository;
        }

        public async Task<Article> Execute(UpdateArticleContract contract)
        {
            return await _articleRepository.Update(contract.Id, contract.Article);
        }
    }
}

