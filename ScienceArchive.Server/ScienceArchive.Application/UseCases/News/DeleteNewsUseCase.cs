using System;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Dtos.News;
using ScienceArchive.Core.Dtos.News.Request;
using ScienceArchive.Core.Dtos.News.Response;
using ScienceArchive.Core.Interfaces.Mappers;
using ScienceArchive.Core.Interfaces.Repositories;
using ScienceArchive.Core.Interfaces.UseCases;

namespace ScienceArchive.Application.NewsUseCases
{
    public class DeleteNewsUseCase : IUseCase<DeleteNewsResponseDto, DeleteNewsRequestDto>
    {
        private readonly INewsRepository _newsRepository;

        public DeleteNewsUseCase(INewsRepository newsRepository)
        {
            if (newsRepository is null)
            {
                throw new ArgumentNullException(nameof(newsRepository));
            }

            _newsRepository = newsRepository;
        }

        public async Task<DeleteNewsResponseDto> Execute(DeleteNewsRequestDto dto)
        {
            var deletedNewsId = await _newsRepository.Delete(dto.Id);
            return new(deletedNewsId);
        }
    }
}

