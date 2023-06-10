using System;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Services.NewsContracts;

namespace ScienceArchive.Core.Services
{
    /// <summary>
    /// Functionality of news service
    /// </summary>
    public interface INewsService
    {
        /// <summary>
        /// Get all news
        /// </summary>
        /// <returns>All news</returns>
        Task<List<News>> GetAll(GetAllNewsContract contract);

        /// <summary>
        /// Create news
        /// </summary>
        /// <param name="contract">Contract to create news</param>
        /// <returns>Created news</returns>
        Task<News> Create(CreateNewsContract contract);

        /// <summary>
        /// Update news
        /// </summary>
        /// <param name="contract">Contract to update news</param>
        /// <returns>Updated news</returns>
        Task<News> Update(UpdateNewsContract contract);

        /// <summary>
        /// Delete news
        /// </summary>
        /// <param name="contract">Contract to delete news</param>
        /// <returns>Deleted news ID</returns>
        Task<Guid> Delete(DeleteNewsContract contract);
    }
}

