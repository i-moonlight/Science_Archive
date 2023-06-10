using System;
namespace ScienceArchive.Core.Services.ArticleContracts
{
    /// <summary>
    /// Contract to delete article
    /// </summary>
    /// <param name="ArticleId">Article ID to delete</param>
    public record DeleteArticleContract(Guid ArticleId);
}

