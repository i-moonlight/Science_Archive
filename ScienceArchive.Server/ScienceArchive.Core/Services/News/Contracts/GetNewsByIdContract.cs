using ScienceArchive.Core.Domain.Aggregates.News.ValueObjects;

namespace ScienceArchive.Core.Services.NewsContracts;

/// <summary>
/// Contract to get news with specified ID
/// </summary>
/// <param name="Id">Id of the news to find</param>
public record GetNewsByIdContract(NewsId Id);