using System;
using ScienceArchive.Application.Dtos.News.Request;
using ScienceArchive.Application.Dtos.News.Response;
using ScienceArchive.Application.Interfaces.Interactors;

namespace ScienceArchive.Application.Interactors
{
    public class NewsInteractor : INewsInteractor
    {
        public NewsInteractor()
        {
        }

        /// <inheritdoc/>
        public Task<CreateNewsResponseDto> CreateNews(CreateNewsRequestDto dto)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<DeleteNewsResponseDto> DeleteNews(DeleteNewsRequestDto dto)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<GetAllNewsResponseDto> GetAllNews(GetAllNewsRequestDto dto)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<UpdateNewsResponseDto> UpdateNews(UpdateNewsRequestDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

