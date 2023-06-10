using System;
using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.ArticleContracts;

namespace ScienceArchive.BusinessLogic.ArticleUseCases
{
    public class CreateArticleUseCase : IUseCase<Article, CreateArticleContract>
    {
        private readonly IArticleRepository _articleRepository;

        public CreateArticleUseCase(IArticleRepository articleRepository)
        {
            if (articleRepository is null)
            {
                throw new ArgumentNullException(nameof(articleRepository));
            }

            _articleRepository = articleRepository;
        }

        public async Task<Article> Execute(CreateArticleContract contract)
        {
            return await _articleRepository.Create(contract.Article);
        }
    }
}

