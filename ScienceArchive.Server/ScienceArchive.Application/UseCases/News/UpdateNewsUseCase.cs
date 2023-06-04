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
    public class UpdateNewsUseCase : IUseCase<UpdateNewsResponseDto, UpdateNewsRequestDto>
    {
        private readonly INewsRepository _newsRepository;
        private readonly IMapper<News, NewsDto> _newsMapper;

        public UpdateNewsUseCase(INewsRepository newsRepository, IMapper<News, NewsDto> newsMapper)
        {
            if (newsRepository is null)
            {
                throw new ArgumentNullException(nameof(newsRepository));
            }

            if (newsMapper is null)
            {
                throw new ArgumentNullException(nameof(newsMapper));
            }

            _newsRepository = newsRepository;
            _newsMapper = newsMapper;
        }

        public async Task<UpdateNewsResponseDto> Execute(UpdateNewsRequestDto dto)
        {
            var newNews = _newsMapper.MapToEntity(dto.News);
            var updatedNews = await _newsRepository.Update(dto.Id, newNews);

            return new(_newsMapper.MapToModel(updatedNews));
        }
    }
}

