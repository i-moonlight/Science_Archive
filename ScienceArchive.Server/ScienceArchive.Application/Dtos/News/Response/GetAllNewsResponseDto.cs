namespace ScienceArchive.Application.Dtos.News.Response;

/// <summary>
/// Response contract of getting all news
/// </summary>
/// <param name="News">All existing news</param>
public record GetAllNewsResponseDto(List<NewsDto> News);