using System;
namespace ScienceArchive.Application.Dtos.News.Request
{
    /// <summary>
    /// Request contract to create news
    /// </summary>
    /// <param name="News">News to create</param>
    public record CreateNewsRequestDto(NewsDto News);
}

