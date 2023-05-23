using System;
using ScienceArchive.Core.Dtos.News.Request;
using ScienceArchive.Core.Dtos.News.Response;
using ScienceArchive.Core.Interfaces.UseCases;

namespace ScienceArchive.Application.UseCases.News
{
    public class GetAllNewsUseCase : IUseCase<GetAllNewsResponseDto, GetAllNewsRequestDto>
    {
        public GetAllNewsUseCase()
        {
        }

        public Task<GetAllNewsResponseDto> Execute(GetAllNewsRequestDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

