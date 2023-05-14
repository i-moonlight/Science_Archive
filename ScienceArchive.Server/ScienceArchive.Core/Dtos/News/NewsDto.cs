using System;
namespace ScienceArchive.Core.Dtos.News
{
    /// <summary>
    /// News DTO
    /// </summary>
    public record NewsDto
    {
        /// <summary>
        /// News ID
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// News title
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// News body
        /// </summary>
        public required string Body { get; set; }

        /// <summary>
        /// Date when news was created
        /// </summary>
        public required DateTime CreationDate { get; set; }
    }
}

