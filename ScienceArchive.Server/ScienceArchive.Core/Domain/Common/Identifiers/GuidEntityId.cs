using ScienceArchive.Core.Exceptions;

namespace ScienceArchive.Core.Domain.Common.Identifiers;

/// <summary>
/// Represents entity identifier
/// which uses Guid as its value
/// </summary>
/// <typeparam name="T">Type of derived class</typeparam>
public abstract class GuidEntityId<T> : EntityId<Guid> 
	where T : GuidEntityId<T>
{
	protected GuidEntityId(Guid value) : base(value)
	{
	}

	/// <summary>
	/// Create new entity ID
	/// </summary>
	/// <returns>New instance of entity ID</returns>
	public static T CreateNew()
	{
		return CreateFromGuid(Guid.NewGuid());
	}
	
	/// <summary>
	/// Create new entity ID from
	/// string value representation
	/// </summary>
	/// <param name="value">String ID representation</param>
	/// <returns>New instance of entity ID</returns>
	/// <exception cref="InvalidEntityIdException">
	/// Thrown if string value of ID is invalid
	/// </exception>
	public static T CreateFromString(string value)
	{
		if (!Guid.TryParse(value, out var idValue))
		{
			throw new InvalidEntityIdException($"Invalid ID value: {value}");
		}
		
		return CreateFromGuid(idValue);
	}

	/// <summary>
	/// Create new entity ID with
	/// predefined value
	/// </summary>
	/// <param name="value">ID value</param>
	/// <returns>New instance of entity ID</returns>
	/// <exception cref="TypeInitializationException">
	/// Thrown when derived type is
	/// invalid and cannot be initialized
	/// </exception>
	/// <exception cref="InvalidEntityIdException">
	/// Thrown if ID value is invalid
	/// </exception>
	public static T CreateFromGuid(Guid value)
	{
		try
		{
			var newInstance = Activator.CreateInstance(typeof(T), value);

			if (newInstance is null)
			{
				throw new TypeInitializationException(nameof(T), null);
			}

			return (T)newInstance;
		}
		catch (Exception ex)
		{
			throw new InvalidEntityIdException($"Cannot create new instance of ${typeof(T).Name}", ex);
		}
	}

	/// <summary>
	/// Get string representation
	/// of ID value
	/// </summary>
	/// <returns>String representation of ID value</returns>
	public override string ToString()
	{
		return Value.ToString();
	}
	
	/// <inheritdoc />
	public override bool Equals(EntityId<Guid> compareId)
	{
		return compareId.Value.Equals(Value);
	}
}