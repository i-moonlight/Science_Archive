﻿namespace ScienceArchive.Application.Dtos.News;

/// <summary>
/// News DTO
/// </summary>
public record NewsDto
{
    /// <summary>
    /// News ID
    /// </summary>
    public string? Id { get; set; }
    
    /// <summary>
    /// Author ID
    /// </summary>
    public required string AuthorId { get; set; }

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
    public DateTime? CreationDate { get; set; }
    
    /// <summary>
    /// Date when news were last updated
    /// </summary>
    public DateTime? LastUpdatedDate { get; set; }
}