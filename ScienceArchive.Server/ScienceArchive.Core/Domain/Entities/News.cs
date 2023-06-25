using ScienceArchive.Core.Domain.Common;

namespace ScienceArchive.Core.Domain.Entities;

/// <summary>
/// News entity. Represents
/// news of the system
/// </summary>
public class News : BaseEntity
{
    public News(Guid? id = null) : base(id)
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
    /// Date when news was created
    /// </summary>
    public required DateTime CreationDate { get; set; }
}