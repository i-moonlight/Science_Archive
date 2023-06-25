using ScienceArchive.Core.Domain.Entities;

namespace ScienceArchive.Core.Services.NewsContracts;

/// <summary>
/// Contract to create news
/// </summary>
/// <param name="News">News to create</param>
public record CreateNewsContract(News News);