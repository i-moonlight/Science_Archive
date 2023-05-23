using System;
using ScienceArchive.Core.Dtos.ArticleRequest;
using ScienceArchive.Core.Dtos.ArticleResponse;
using ScienceArchive.Core.Interfaces.UseCases;

namespace ScienceArchive.Application.UseCases.Article
{
    public class GetAllArticlesUseCase : IUseCase<GetAllArticlesResponseDto, GetAllArticlesRequestDto>
    {
        public GetAllArticlesUseCase()
        {
        }

        public Task<GetAllArticlesResponseDto> Execute(GetAllArticlesRequestDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

