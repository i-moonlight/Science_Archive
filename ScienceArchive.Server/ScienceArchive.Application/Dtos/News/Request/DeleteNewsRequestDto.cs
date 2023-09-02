namespace ScienceArchive.Application.Dtos.News.Request;

/// <summary>
/// Request contract to delete news
/// </summary>
/// <param name="Id">Identifier of the news to delete</param>
public record DeleteNewsRequestDto(string Id);