using System;
namespace ScienceArchive.Core.Dtos.ArticleResponse
{
    /// <summary>
    /// Response contract of article deletion
    /// </summary>
    /// <param name="Id">ID of the deleted article</param>
    public record DeleteArticleResponseDto(Guid Id);
}

