using ScienceArchive.Core.Domain.Aggregates.Article.ValueObjects;
using ScienceArchive.Core.Domain.Aggregates.User.ValueObjects;
using ScienceArchive.Core.Domain.Common;

namespace ScienceArchive.Core.Domain.Aggregates.User;

/// <summary>
/// Represents user which have written any article
/// </summary>
public class Author : Entity<UserId>
{
	public Author(UserId id) : base(id)
	{
	}
	
	/// <summary>
	/// Name of author
	/// </summary>
	public required string Name { get; set; }
	
	/// <summary>
	/// Description of author
	/// </summary>
	public string? Description { get; set; }
	
	/// <summary>
	/// Identifiers of all articles
	/// </summary>
	public required List<ArticleId> ArticlesIds { get; set; }
}