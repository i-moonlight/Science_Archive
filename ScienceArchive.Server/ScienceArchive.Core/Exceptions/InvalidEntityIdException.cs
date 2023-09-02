namespace ScienceArchive.Core.Exceptions;

/// <summary>
/// Represents exception if it is not possible
/// to create new instance of entity ID
/// </summary>
public class InvalidEntityIdException : Exception
{
	public InvalidEntityIdException(string? message) 
		: base(message)
	{
	}

	public InvalidEntityIdException(string? message, Exception innerException)
		: base(message, innerException)
	{
	}
}