using System;
using ScienceArchive.Core.Domain.Common;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Dtos;
using ScienceArchive.Core.Dtos.User;

namespace ScienceArchive.Core.Interfaces.Mappers
{
    public interface IMapper<TEntity, TModel>
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
        /// <param name="dto">Model to map</param>
        /// <param name="id">ID of the entity</param>
        /// <returns>Mapped entity</returns>
        public TEntity MapToEntity(TModel model, Guid? id = null);
    }
}

