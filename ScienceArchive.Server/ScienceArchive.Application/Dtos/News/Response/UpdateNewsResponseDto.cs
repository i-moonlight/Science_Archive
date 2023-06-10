using System;
namespace ScienceArchive.Application.Dtos.News.Response
{
    /// <summary>
    /// Response contract of news update
    /// </summary>
    /// <param name="News">Updated news</param>
    public record UpdateNewsResponseDto(NewsDto News);
}

