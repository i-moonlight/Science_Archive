using System;
namespace ScienceArchive.Core.Exceptions
{
    /// <summary>
    /// Exception thrown when entity
    /// was not found for some reason
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public class EntityNotFoundException<TEntity> : Exception
    {
        public EntityNotFoundException()
            : base($"Entity ({typeof(TEntity).FullName} type) was not found!")
        {
        }

        public EntityNotFoundException(string message)
            : base($"Entity ({typeof(TEntity).FullName} type) was not found: {message}")
        {
        }

        public EntityNotFoundException(string message, Exception innerException)
            : base($"Entity ({typeof(TEntity).FullName} type) was not found: {message}", innerException)
        {
        }
    }
}

