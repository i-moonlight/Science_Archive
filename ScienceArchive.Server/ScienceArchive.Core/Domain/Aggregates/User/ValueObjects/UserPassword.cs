using ScienceArchive.Core.Domain.Common;

namespace ScienceArchive.Core.Domain.Aggregates.User.ValueObjects;

/// <summary>
/// Represents user password
/// </summary>
public class UserPassword : ValueObject
{
	/// <summary>
	///	Value of a user password
	/// </summary>
	public string Value { get; set; } = string.Empty;

	/// <summary>
	/// Salt for password
	/// </summary>
	public string Salt { get; set; } = string.Empty;
}