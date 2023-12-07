namespace ScienceArchive.Core.Domain.Aggregates.Article.Enums;

/// <summary>
/// Status of an article
/// </summary>
public enum ArticleStatus
{
	/// <summary>
	/// Article needs to be verified.
	/// It is not visible for users, only for
	/// authors on their profile page 
	/// </summary>
	ToVerify,
	
	/// <summary>
	/// Article is verified successfully
	/// and can be shown to users
	/// </summary>
	Verified,
	
	/// <summary>
	/// Article is verified, but has some
	/// problems and cannot be shown to users 
	/// </summary>
	Cancelled
}