using System;
using ScienceArchive.Core.Domain.Common;

namespace ScienceArchive.Infrastructure.Persistence.Interfaces
{
    /// <summary>
    /// Persistence layer mapper
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TModel">Model type</typeparam>
    public interface IPersistenceMapper<TEntity, TModel>
        where TEntity : BaseEntity
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
        /// <param name="id">ID of the entity</param>
        /// <returns>Mapped entity</returns>
        public TEntity MapToEntity(TModel model, Guid? id = null);
    }
}

