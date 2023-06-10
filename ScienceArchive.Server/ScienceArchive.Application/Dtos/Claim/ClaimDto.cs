using System;
namespace ScienceArchive.Application.Dtos.Claim
{
    /// <summary>
    /// Claim DTO with identifier
    /// </summary>
    public record ClaimDto
    {
        /// <summary>
        /// Identifier of the claim
        /// </summary>
        public required string Id { get; set; }

        /// <summary>
        /// Claim value
        /// </summary>
        public required string Value { get; init; }

        /// <summary>
        /// Claim name
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Claim description
        /// </summary>
        public string? Description { get; set; }
    }
}

