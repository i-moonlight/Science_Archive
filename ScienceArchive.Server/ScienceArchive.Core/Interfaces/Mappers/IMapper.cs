using System;
using ScienceArchive.Core.Domain.Common;
using ScienceArchive.Core.Domain.Entities;
using ScienceArchive.Core.Dtos;
using ScienceArchive.Core.Dtos.User;

namespace ScienceArchive.Core.Interfaces.Mappers
{
    public interface IMapper<TEntity, TDto>
        where TEntity : BaseEntity
    {
        /// <summary>
        /// Map entity to DTO
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
        public TEntity MapToEntity(TDto dto, Guid? id = null);
    }
}

