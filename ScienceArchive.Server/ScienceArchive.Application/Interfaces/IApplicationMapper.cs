namespace ScienceArchive.Application.Interfaces;

public interface IApplicationMapper<TEntity, TDto>
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
    /// <returns>Mapped entity</returns>
    public TEntity MapToEntity(TDto dto);
}