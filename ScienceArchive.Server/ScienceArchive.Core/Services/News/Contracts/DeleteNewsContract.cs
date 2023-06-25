namespace ScienceArchive.Core.Services.NewsContracts;

/// <summary>
/// Contract to delete news
/// </summary>
/// <param name="NewsId">News ID</param>
public record DeleteNewsContract(Guid NewsId);