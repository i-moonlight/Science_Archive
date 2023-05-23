using System;
using ScienceArchive.Core.Dtos.News.Request;
using ScienceArchive.Core.Dtos.News.Response;
using ScienceArchive.Core.Interfaces.UseCases;

namespace ScienceArchive.Application.UseCases.News
{
    public class CreateNewsUseCase : IUseCase<CreateNewsResponseDto, CreateNewsRequestDto>
    {
        public CreateNewsUseCase()
        {
        }

        public Task<CreateNewsResponseDto> Execute(CreateNewsRequestDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

