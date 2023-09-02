using ScienceArchive.Core.Domain.Aggregates.News;
using ScienceArchive.Core.Domain.Aggregates.News.ValueObjects;

namespace ScienceArchive.Core.Services.NewsContracts;

/// <summary>
/// Contract to update news
/// </summary>
/// <param name="Id">News ID to update</param>
/// <param name="News">News</param>
public record UpdateNewsContract(NewsId Id, News News);