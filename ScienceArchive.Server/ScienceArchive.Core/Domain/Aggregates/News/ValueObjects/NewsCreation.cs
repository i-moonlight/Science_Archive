using ScienceArchive.Core.Domain.Aggregates.User.ValueObjects;
using ScienceArchive.Core.Domain.Common;

namespace ScienceArchive.Core.Domain.Aggregates.News.ValueObjects;

public class NewsMetadata : ValueObject
{
	/// <summary>
	/// News creator
	/// </summary>
	public required UserId AuthorId { get; set; }
	
	/// <summary>
	/// Date when news was created
	/// </summary>
	public required DateTime CreationDate { get; set; }
	
	/// <summary>
	/// Date when news were last updated
	/// </summary>
	public DateTime? LastUpdatedDate { get; set; }
}