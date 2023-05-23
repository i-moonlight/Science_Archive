using System;
using ScienceArchive.Core.Dtos.News.Request;
using ScienceArchive.Core.Dtos.News.Response;
using ScienceArchive.Core.Interfaces.UseCases;

namespace ScienceArchive.Application.UseCases.News
{
    public class DeleteNewsUseCase : IUseCase<DeleteNewsResponseDto, DeleteNewsRequestDto>
    {
        public DeleteNewsUseCase()
        {
        }

        public Task<DeleteNewsResponseDto> Execute(DeleteNewsRequestDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

