using System;
using ScienceArchive.Core.Domain.Entities;

namespace ScienceArchive.Core.Services.NewsContracts
{
    /// <summary>
    /// Contract to update news
    /// </summary>
    /// <param name="Id">News ID to update</param>
    /// <param name="News">News</param>
    public record UpdateNewsContract(Guid Id, News News);
}

