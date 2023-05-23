using System;
using ScienceArchive.Core.Dtos.ArticleRequest;
using ScienceArchive.Core.Dtos.ArticleResponse;
using ScienceArchive.Core.Interfaces.UseCases;

namespace ScienceArchive.Application.UseCases.Article
{
    public class DeleteArticleUseCase : IUseCase<DeleteArticleResponseDto, DeleteArticleRequestDto>

    {
        public DeleteArticleUseCase()
        {
        }

        public Task<DeleteArticleResponseDto> Execute(DeleteArticleRequestDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

