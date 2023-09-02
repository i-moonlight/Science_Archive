namespace ScienceArchive.Infrastructure.Persistence.Exceptions;

/// <summary>
/// Represents error in persistence
/// layer when some object cannot be saved,
/// changed or deleted
/// </summary>
public class PersistenceException : Exception
{
    public PersistenceException()
        : base("An error occurred while persistence operation execution!")
    {
    }

    public PersistenceException(string message)
        : base($"An error occurred while persistence operation execution: {message}")
    {
    }

    public PersistenceException(string message, Exception innerException)
        : base(
            $"An error occurred while persistence operation execution: {message}",
            innerException)
    {
    }
}
