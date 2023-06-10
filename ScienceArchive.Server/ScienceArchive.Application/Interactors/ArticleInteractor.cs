using System;
using ScienceArchive.Application.Dtos.Article.Request;
using ScienceArchive.Application.Dtos.Article.Response;
using ScienceArchive.Application.Interfaces.Interactors;

namespace ScienceArchive.Application.Interactors
{
    public class ArticleInteractor : IArticleInteractor
    {
        public ArticleInteractor()
        {
        }

        /// <inheritdoc/>
        public Task<CreateArticleResponseDto> CreateArticle(CreateArticleRequestDto dto)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<DeleteArticleResponseDto> DeleteArticle(DeleteArticleRequestDto dto)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<GetAllArticlesResponseDto> GetAllArticles(GetAllArticlesRequestDto dto)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<UpdateArticleResponseDto> UpdateArticle(UpdateArticleRequestDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

