using System;
using ScienceArchive.Core.Dtos.News.Request;
using ScienceArchive.Core.Dtos.News.Response;

namespace ScienceArchive.Core.Interfaces.Services
{
    /// Base functionality of news service
    public interface INewsService
    {
        /// <summary>
        /// Get all news
        /// </summary>
        /// <param name="contract">Request contract to get all news</param>
        /// <returns>Get all news response contract</returns>
        Task<GetAllNewsResponseDto> GetAll(GetAllNewsRequestDto contract);

        /// <summary>
        /// Create news
        /// </summary>
        /// <param name="contract">Request contract to create news</param>
        /// <returns>Create news response contract</returns>
        Task<CreateNewsResponseDto> Create(CreateNewsRequestDto contract);

        /// <summary>
        /// Update news
        /// </summary>
        /// <param name="contract">Request contract to update news</param>
        /// <returns>Update news response contract</returns>
        Task<UpdateNewsResponseDto> Update(UpdateNewsRequestDto contract);

        /// <summary>
        /// Delete news
        /// </summary>
        /// <param name="contract">Request contract to delete news</param>
        /// <returns>Delete news response contract</returns>
        Task<DeleteNewsResponseDto> Delete(DeleteNewsRequestDto contract);
    }
}

