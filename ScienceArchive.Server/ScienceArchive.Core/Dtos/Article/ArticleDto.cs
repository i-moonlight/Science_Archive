using System;
using ScienceArchive.Core.Dtos.User;

namespace ScienceArchive.Core.Dtos.Article
{
    /// <summary>
    /// Article DTO
    /// </summary>
    public record ArticleDto
    {
        /// <summary>
        /// Article ID
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Article's title
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Author of an article
        /// </summary>
        public required UserDto Author { get; set; }

        /// <summary>
        /// Date when article was created
        /// </summary>
        public required DateTime CreationDate { get; set; }

        /// <summary>
        /// Article description
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Path to a document linked to article
        /// </summary>
        public string? DocumentPath { get; set; }
    }
}

