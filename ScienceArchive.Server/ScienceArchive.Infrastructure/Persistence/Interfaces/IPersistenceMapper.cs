namespace ScienceArchive.Infrastructure.Persistence.Interfaces;

/// <summary>
/// Persistence layer mapper
/// </summary>
/// <typeparam name="TEntity">Entity type</typeparam>
/// <typeparam name="TModel">Model type</typeparam>
internal interface IPersistenceMapper<TEntity, TModel>
{
    /// <summary>
    /// Map entity to model type
    /// </summary>
    /// <param name="entity">Entity to map</param>
    /// <returns>Mapped model</returns>
    public TModel MapToModel(TEntity entity);

    /// <summary>
    /// Map model to entity
    /// </summary>
    /// <param name="model">Model to map</param>
    /// <returns>Mapped entity</returns>
    public TEntity MapToEntity(TModel model);
}