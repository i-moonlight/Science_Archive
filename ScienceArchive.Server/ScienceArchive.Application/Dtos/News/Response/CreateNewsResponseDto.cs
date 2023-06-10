using System;
namespace ScienceArchive.Application.Dtos.News.Response
{
    /// <summary>
    /// Response contract of news creation
    /// </summary>
    /// <param name="News">Created news</param>
    public record CreateNewsResponseDto(NewsDto News);
}

