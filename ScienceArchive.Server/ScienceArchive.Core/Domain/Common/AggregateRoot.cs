namespace ScienceArchive.Core.Domain.Common;

/// <summary>
/// Represents main entity in aggregate
/// </summary>
/// <typeparam name="TId">Type of ID used in this aggregate root</typeparam>
public class AggregateRoot<TId> : Entity<TId> 
{
	protected AggregateRoot(TId id) : base(id)
	{
	}
}