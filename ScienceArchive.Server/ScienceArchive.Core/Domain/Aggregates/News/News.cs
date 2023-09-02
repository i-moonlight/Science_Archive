using ScienceArchive.Core.Domain.Aggregates.News.ValueObjects;
using ScienceArchive.Core.Domain.Aggregates.User.ValueObjects;
using ScienceArchive.Core.Domain.Common;

namespace ScienceArchive.Core.Domain.Aggregates.News;

/// <summary>
/// News entity. Represents
/// news of the system
/// </summary>
public class News : Entity<NewsId>
{
    public News(NewsId? id = null) : base(id ?? NewsId.CreateNew())
    {
    }

    /// <summary>
    /// News title
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// News body
    /// </summary>
    public required string Body { get; set; }

    /// <summary>
    /// News metadata. Contains information about
    /// author, creation and last update date
    /// </summary>
    public required NewsMetadata Metadata { get; set; }
}