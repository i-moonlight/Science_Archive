using System;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Dtos.Article;
using ScienceArchive.Core.Dtos.Article.Request;
using ScienceArchive.Core.Dtos.Article.Response;
using ScienceArchive.Core.Interfaces.Mappers;
using ScienceArchive.Core.Interfaces.Repositories;
using ScienceArchive.Core.Interfaces.UseCases;

namespace ScienceArchive.Application.ArticleUseCases
{
    public class DeleteArticleUseCase : IUseCase<DeleteArticleResponseDto, DeleteArticleRequestDto>
    {
        private readonly IArticleRepository _articleRepository;

        public DeleteArticleUseCase(IArticleRepository articleRepository, IMapper<Article, ArticleDto> articleMapper)
        {
            if (articleRepository is null)
            {
                throw new ArgumentNullException(nameof(articleRepository));
            }

            _articleRepository = articleRepository;
        }

        public async Task<DeleteArticleResponseDto> Execute(DeleteArticleRequestDto dto)
        {
            var deletedArticleId = await _articleRepository.Delete(dto.Id);
            return new(deletedArticleId);
        }
    }
}

