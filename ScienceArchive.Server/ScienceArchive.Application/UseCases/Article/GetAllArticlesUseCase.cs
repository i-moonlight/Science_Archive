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
    public class GetAllArticlesUseCase : IUseCase<GetAllArticlesResponseDto, GetAllArticlesRequestDto>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper<Article, ArticleDto> _articleMapper;

        public GetAllArticlesUseCase(IArticleRepository articleRepository, IMapper<Article, ArticleDto> articleMapper)
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

        public async Task<GetAllArticlesResponseDto> Execute(GetAllArticlesRequestDto dto)
        {
            var articles = await _articleRepository.GetAll();
            var articlesDtos = articles.Select(article => _articleMapper.MapToModel(article)).ToList();

            return new(articlesDtos);
        }
    }
}

