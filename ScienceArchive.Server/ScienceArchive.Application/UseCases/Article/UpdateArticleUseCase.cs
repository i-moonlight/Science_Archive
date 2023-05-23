using System;
using ScienceArchive.Core.Dtos.ArticleRequest;
using ScienceArchive.Core.Dtos.ArticleResponse;
using ScienceArchive.Core.Interfaces.UseCases;

namespace ScienceArchive.Application.UseCases.Article
{
    public class UpdateArticleUseCase : IUseCase<UpdateArticleResponseDto, UpdateArticleRequestDto>
    {
        public UpdateArticleUseCase()
        {
        }

        public Task<UpdateArticleResponseDto> Execute(UpdateArticleRequestDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

