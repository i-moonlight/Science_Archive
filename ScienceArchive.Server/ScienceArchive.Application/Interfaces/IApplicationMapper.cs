using System;
using ScienceArchive.Core.Domain.Common;

namespace ScienceArchive.Application.Interfaces
{
    public interface IApplicationMapper<TEntity, TDto>
        where TEntity : BaseEntity
    {
        /// <summary>
        /// Map entity to DTO type
        /// </summary>
        /// <param name="entity">Entity to map</param>
        /// <returns>Mapped DTO</returns>
        public TDto MapToDto(TEntity entity);

        /// <summary>
        /// Map DTO to entity
        /// </summary>
        /// <param name="dto">DTO to map</param>
        /// <param name="id">ID of the entity</param>
        /// <returns>Mapped entity</returns>
        public TEntity MapToEntity(TDto dto, string? id = null);
    }
}

