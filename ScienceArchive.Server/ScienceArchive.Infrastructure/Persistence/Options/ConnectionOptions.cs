using System;
namespace ScienceArchive.Infrastructure.Persistence.Options
{
    /// <summary>
    /// Options of connection to different data sources
    /// </summary>
    public class ConnectionOptions
    {
        public required string PostgresConnectionString { get; set; }
    }
}

