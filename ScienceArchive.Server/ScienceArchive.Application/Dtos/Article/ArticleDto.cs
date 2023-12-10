namespace ScienceArchive.Application.Dtos.Article;

/// <summary>
/// Article DTO
/// </summary>
public record ArticleDto
{
    /// <summary>
    /// Article ID
    /// </summary>
    public string? Id { get; set; }
    
    /// <summary>
    /// Identifier of the category of article
    /// </summary>
    public required string CategoryId { get; set; }

    /// <summary>
    /// Article's title
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// Article's status
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// Author of an article
    /// </summary>
    public required List<string> AuthorsIds { get; set; }

    /// <summary>
    /// Path to a document linked to article
    /// </summary>
    public required List<string> DocumentsPaths { get; set; }

    /// <summary>
    /// Date when article was created
    /// </summary>
    public DateTime? CreationDate { get; set; }

    /// <summary>
    /// Article description
    /// </summary>
    public string? Description { get; set; }
}