namespace ScienceArchive.Application.Dtos.News.Response;

/// <summary>
/// Response contract of getting news by its ID
/// </summary>
/// <param name="News">Found news. If no news were found, return null</param>
public record GetNewsByIdResponseDto(NewsDto? News);