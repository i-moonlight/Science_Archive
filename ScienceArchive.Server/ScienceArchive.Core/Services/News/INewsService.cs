using ScienceArchive.Core.Domain.Aggregates.News;
using ScienceArchive.Core.Domain.Aggregates.News.ValueObjects;
using ScienceArchive.Core.Services.NewsContracts;

namespace ScienceArchive.Core.Services;

/// <summary>
/// Contains a set of business-logic methods
/// to interact with news
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
    Task<NewsId> Delete(DeleteNewsContract contract);
}