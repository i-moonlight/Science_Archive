using System;
using System.Xml.Linq;
using ScienceArchive.Core.Domain.Common;

namespace ScienceArchive.Core.Domain.Entities
{
    /// <summary>
    /// Article entity
    /// </summary>
    public class Article : BaseEntity
    {
        public Article(Guid id) : base(id)
        {
        }

        /// <summary>
        /// Article's title
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Author of an article
        /// </summary>
        public required User Author { get; set; }

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

