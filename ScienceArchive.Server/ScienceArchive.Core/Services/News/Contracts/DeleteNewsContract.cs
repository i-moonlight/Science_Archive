using ScienceArchive.Core.Domain.Aggregates.News.ValueObjects;

namespace ScienceArchive.Core.Services.NewsContracts;

/// <summary>
/// Contract to delete news
/// </summary>
/// <param name="Id">News ID</param>
public record DeleteNewsContract(NewsId Id);