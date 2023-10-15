using System;
namespace ScienceArchive.Infrastructure.Persistence.Options;

/// <summary>
/// Options of connection to different data sources
/// </summary>
public class ConnectionOptions
{
    /// <summary>
    /// Connection string for PostgreSQL
    /// </summary>
    public required string PostgresConnectionString { get; set; }
    
    /// <summary>
    /// Connection string for ClickHouse
    /// </summary>
    public required string ClickHouseConnectionString { get; set; }
}