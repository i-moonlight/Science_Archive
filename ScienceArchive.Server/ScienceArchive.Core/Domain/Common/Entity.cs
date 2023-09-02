namespace ScienceArchive.Core.Domain.Common;

/// <summary>
/// Represents object in system which
/// is determined by its identifier
/// </summary>
/// <typeparam name="TId">Type of ID used in this entity</typeparam>
public class Entity<TId>
{
    protected Entity(TId id)
    {
        Id = id;
    }

    /// <summary>
    /// Global identifier of the entity
    /// </summary>
    public TId Id { get; private set; }
}