using System;
using ScienceArchive.Core.Dtos.Claim;

namespace ScienceArchive.Core.Dtos.Role
{
    /// <summary>
    /// Role DTO
    /// </summary>
    public record RoleDto
    {
        /// <summary>
        /// Role ID
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Role name
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Role description
        /// </summary>
        public required string Description { get; set; }

        /// <summary>
        /// Role claims. List of permissions
        /// of a user to perform some
        /// actions in the system
        /// </summary>
        public required List<ClaimDto> Claims { get; init; }
    }
}

