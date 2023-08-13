using ScienceArchive.Application.Dtos.News;
using ScienceArchive.Application.Dtos.News.Request;
using ScienceArchive.Application.Dtos.News.Response;
using ScienceArchive.Application.Interfaces;
using ScienceArchive.Application.Interfaces.Interactors;
using ScienceArchive.Core.Domain.Aggregates.News;
using ScienceArchive.Core.Domain.Aggregates.News.ValueObjects;
using ScienceArchive.Core.Services;
using ScienceArchive.Core.Services.NewsContracts;

namespace ScienceArchive.Application.Interactors
{
    public class NewsInteractor : INewsInteractor
    {
        private readonly INewsService _newsService;
        private readonly IApplicationMapper<News, NewsDto> _newsMapper;

        public NewsInteractor(INewsService newsService, IApplicationMapper<News, NewsDto> newsMapper)
        {
            _newsService = newsService ?? throw new ArgumentNullException(nameof(newsService));
            _newsMapper = newsMapper ?? throw new ArgumentNullException(nameof(newsMapper));
        }

        /// <inheritdoc/>
        public async Task<GetAllNewsResponseDto> GetAllNews(GetAllNewsRequestDto dto)
        {
            var contract = new GetAllNewsContract();
            var news = await _newsService.GetAll(contract);
            var newsDtos = news.Select(newsEntity => _newsMapper.MapToDto(newsEntity)).ToList();

            return new(newsDtos);
        }

        /// <inheritdoc/>
        public async Task<CreateNewsResponseDto> CreateNews(CreateNewsRequestDto dto)
        {
            var contract = new CreateNewsContract(_newsMapper.MapToEntity(dto.News));
            var createdNews = await _newsService.Create(contract);

            return new(_newsMapper.MapToDto(createdNews));
        }

        /// <inheritdoc/>
        public async Task<UpdateNewsResponseDto> UpdateNews(UpdateNewsRequestDto dto)
        {
            var contract = new UpdateNewsContract(NewsId.CreateFromString(dto.Id), _newsMapper.MapToEntity(dto.News));
            var updatedNews = await _newsService.Update(contract);

            return new(_newsMapper.MapToDto(updatedNews));
        }

        /// <inheritdoc/>
        public async Task<DeleteNewsResponseDto> DeleteNews(DeleteNewsRequestDto dto)
        {
            var contract = new DeleteNewsContract(NewsId.CreateFromString(dto.Id));
            var deletedNewsId = await _newsService.Delete(contract);

            return new(deletedNewsId.ToString());
        }
    }
}

