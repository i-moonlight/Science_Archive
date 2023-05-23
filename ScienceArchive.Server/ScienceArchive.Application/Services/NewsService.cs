using System;
using ScienceArchive.Core.Dtos.News.Request;
using ScienceArchive.Core.Dtos.News.Response;
using ScienceArchive.Core.Interfaces.Services;
using ScienceArchive.Core.Interfaces.UseCases;

namespace ScienceArchive.Application.Services
{
    public class NewsService : BaseService, INewsService
    {
        public NewsService(IServiceProvider serviceProvider) : base(serviceProvider) { }

        /// <inheritdoc/>
        public async Task<CreateNewsResponseDto> Create(CreateNewsRequestDto contract)
        {
            return await ExecuteUseCase<CreateNewsResponseDto, CreateNewsRequestDto>(contract);
        }

        /// <inheritdoc/>
        public async Task<DeleteNewsResponseDto> Delete(DeleteNewsRequestDto contract)
        {
            return await ExecuteUseCase<DeleteNewsResponseDto, DeleteNewsRequestDto>(contract);
        }

        /// <inheritdoc/>
        public async Task<GetAllNewsResponseDto> GetAll(GetAllNewsRequestDto contract)
        {
            return await ExecuteUseCase<GetAllNewsResponseDto, GetAllNewsRequestDto>(contract);
        }

        /// <inheritdoc/>
        public async Task<UpdateNewsResponseDto> Update(UpdateNewsRequestDto contract)
        {
            return await ExecuteUseCase<UpdateNewsResponseDto, UpdateNewsRequestDto>(contract);
        }
    }
}

