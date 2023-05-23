using System;
using ScienceArchive.Core.Dtos.ArticleRequest;
using ScienceArchive.Core.Dtos.ArticleResponse;
using ScienceArchive.Core.Interfaces.UseCases;

namespace ScienceArchive.Application.UseCases.Article
{
    public class CreateArticleUseCase : IUseCase<CreateArticleResponseDto, CreateArticleRequestDto>
    {
        public CreateArticleUseCase()
        {
        }

        public Task<CreateArticleResponseDto> Execute(CreateArticleRequestDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

