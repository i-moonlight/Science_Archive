using System;
namespace ScienceArchive.Core.Domain.Common
{
    /// <summary>
    /// Represents base entity
    /// </summary>
    public class BaseEntity
    {
        public BaseEntity(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            Id = id;
        }

        /// <summary>
        /// Global identifier of the entity
        /// </summary>
        public Guid Id { get; private set; }
    }
}

