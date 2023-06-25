namespace ScienceArchive.Application.Dtos.News.Response;

/// <summary>
/// Response contract of news deletion
/// </summary>
/// <param name="Id">Identifier of the news</param>
public record DeleteNewsResponseDto(Guid Id);