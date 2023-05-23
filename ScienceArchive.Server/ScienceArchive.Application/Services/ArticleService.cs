using System;
using ScienceArchive.Core.Dtos.ArticleRequest;
using ScienceArchive.Core.Dtos.ArticleResponse;
using ScienceArchive.Core.Interfaces.Services;

namespace ScienceArchive.Application.Services
{
    public class ArticleService : BaseService, IArticleService
    {
        public ArticleService(IServiceProvider serviceProvider) : base(serviceProvider) { }

        /// <inheritdoc/>
        public async Task<CreateArticleResponseDto> Create(CreateArticleRequestDto contract)
        {
            return await ExecuteUseCase<CreateArticleResponseDto, CreateArticleRequestDto>(contract);
        }

        /// <inheritdoc/>
        public async Task<DeleteArticleResponseDto> Delete(DeleteArticleRequestDto contract)
        {
            return await ExecuteUseCase<DeleteArticleResponseDto, DeleteArticleRequestDto>(contract);
        }

        /// <inheritdoc/>
        public async Task<GetAllArticlesResponseDto> GetAll(GetAllArticlesRequestDto contract)
        {
            return await ExecuteUseCase<GetAllArticlesResponseDto, GetAllArticlesRequestDto>(contract);
        }

        /// <inheritdoc/>
        public async Task<UpdateArticleResponseDto> Update(UpdateArticleRequestDto contract)
        {
            return await ExecuteUseCase<UpdateArticleResponseDto, UpdateArticleRequestDto>(contract);
        }
    }
}

