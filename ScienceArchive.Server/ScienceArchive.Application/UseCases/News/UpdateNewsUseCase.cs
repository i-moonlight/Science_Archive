using System;
using ScienceArchive.Core.Dtos.News.Request;
using ScienceArchive.Core.Dtos.News.Response;
using ScienceArchive.Core.Interfaces.UseCases;

namespace ScienceArchive.Application.UseCases.News
{
    public class UpdateNewsUseCase : IUseCase<UpdateNewsResponseDto, UpdateNewsRequestDto>
    {
        public UpdateNewsUseCase()
        {
        }

        public Task<UpdateNewsResponseDto> Execute(UpdateNewsRequestDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

