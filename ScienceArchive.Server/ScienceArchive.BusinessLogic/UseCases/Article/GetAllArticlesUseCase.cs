using System;
using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.ArticleContracts;

namespace ScienceArchive.BusinessLogic.ArticleUseCases
{
    public class GetAllArticlesUseCase : IUseCase<List<Article>, GetAllArticlesContract>
    {
        private readonly IArticleRepository _articleRepository;

        public GetAllArticlesUseCase(IArticleRepository articleRepository)
        {
            if (articleRepository is null)
            {
                throw new ArgumentNullException(nameof(articleRepository));
            }

            _articleRepository = articleRepository;
        }

        public async Task<List<Article>> Execute(GetAllArticlesContract contract)
        {
            return await _articleRepository.GetAll();
        }
    }
}

