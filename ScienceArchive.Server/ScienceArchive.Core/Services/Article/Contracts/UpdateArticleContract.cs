using System;
using ScienceArchive.Core.Domain.Entities;

namespace ScienceArchive.Core.Services.ArticleContracts
{
    /// <summary>
    /// Contract to update article
    /// </summary>
    /// <param name="Id">ID of the article to update</param>
    /// <param name="Article">New article</param>
    public record UpdateArticleContract(Guid Id, Article Article);
}

