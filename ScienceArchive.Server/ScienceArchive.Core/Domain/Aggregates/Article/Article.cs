using ScienceArchive.Core.Domain.Aggregates.Article.Enums;
using ScienceArchive.Core.Domain.Aggregates.Article.ValueObjects;
using ScienceArchive.Core.Domain.Aggregates.Category.ValueObjects;
using ScienceArchive.Core.Domain.Aggregates.User.ValueObjects;
using ScienceArchive.Core.Domain.Common;

namespace ScienceArchive.Core.Domain.Aggregates.Article;

/// <summary>
/// Article entity
/// </summary>
public class Article : Entity<ArticleId>
{
    public Article(ArticleId? id = null) : base(id ?? ArticleId.CreateNew())
    {
    }
    
    /// <summary>
    /// Category of an article
    /// </summary>
    public required CategoryId CategoryId { get; set; }
    
    /// <summary>
    /// Article's title
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// Author of an article
    /// </summary>
    public required List<UserId> AuthorsIds { get; set; }
    
    /// <summary>
    /// Current status of an article
    /// </summary>
    public required ArticleStatus Status { get; set; }

    /// <summary>
    /// Date when article was created
    /// </summary>
    public required DateTime CreationDate { get; set; }

    /// <summary>
    /// Linked article document
    /// </summary>
    public required List<ArticleDocument> Documents { get; set; }
    
    /// <summary>
    /// Article description
    /// </summary>
    public string? Description { get; set; }
}