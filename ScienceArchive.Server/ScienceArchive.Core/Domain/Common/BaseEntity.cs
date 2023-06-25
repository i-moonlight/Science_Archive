namespace ScienceArchive.Core.Domain.Common;

/// <summary>
/// Represents base entity
/// </summary>
public class BaseEntity
{
    protected BaseEntity(Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
    }

    /// <summary>
    /// Global identifier of the entity
    /// </summary>
    public Guid Id { get; private set; }
}