using System;
using ScienceArchive.BusinessLogic.Interfaces;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Repositories;
using ScienceArchive.Core.Services.ArticleContracts;

namespace ScienceArchive.BusinessLogic.ArticleUseCases
{
    public class DeleteArticleUseCase : IUseCase<Guid, DeleteArticleContract>
    {
        private readonly IArticleRepository _articleRepository;

        public DeleteArticleUseCase(IArticleRepository articleRepository)
        {
            if (articleRepository is null)
            {
                throw new ArgumentNullException(nameof(articleRepository));
            }

            _articleRepository = articleRepository;
        }

        public async Task<Guid> Execute(DeleteArticleContract contract)
        {
            return await _articleRepository.Delete(contract.ArticleId);
        }
    }
}

