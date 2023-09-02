namespace ScienceArchive.Core.Domain.Common.Identifiers;

/// <summary>
/// Represents identifier of an entity
/// </summary>
public abstract class EntityId<T> : ValueObject
{
	protected EntityId(T value)
	{
		Value = value;
	}
	
	/// <summary>
	/// The value of the identifier
	/// </summary>
	public T Value { get; protected set; }

	/// <summary>
	/// Check if ID value is
	/// equal to another entity ID
	/// </summary>
	/// <param name="compareValue">ID value to compare</param>
	/// <returns>True, if they are equal, otherwise, false</returns>
	public abstract bool Equals(EntityId<T> compareValue);
}