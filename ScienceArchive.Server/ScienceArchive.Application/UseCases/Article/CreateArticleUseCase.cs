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
    public class CreateArticleUseCase : IUseCase<CreateArticleResponseDto, CreateArticleRequestDto>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper<Article, ArticleDto> _articleMapper;

        public CreateArticleUseCase(IArticleRepository articleRepository, IMapper<Article, ArticleDto> articleMapper)
        {
            if (articleRepository is null)
            {
                throw new ArgumentNullException(nameof(articleRepository));
            }

            if (articleMapper is null)
            {
                throw new ArgumentNullException(nameof(articleMapper));
            }

            _articleRepository = articleRepository;
            _articleMapper = articleMapper;
        }

        public async Task<CreateArticleResponseDto> Execute(CreateArticleRequestDto dto)
        {
            var article = _articleMapper.MapToEntity(dto.Article);
            var createdArticle = await _articleRepository.Create(article);

            return new(_articleMapper.MapToModel(createdArticle));
        }
    }
}

