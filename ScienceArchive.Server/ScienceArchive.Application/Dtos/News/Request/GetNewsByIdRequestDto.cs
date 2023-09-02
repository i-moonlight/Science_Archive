namespace ScienceArchive.Application.Dtos.News.Request;

/// <summary>
/// Request contract to get news by its ID
/// </summary>
/// <param name="Id">ID of a news to find</param>
public record GetNewsByIdRequestDto(string Id);