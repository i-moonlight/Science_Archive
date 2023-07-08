using System.Data;
using Npgsql;

namespace ScienceArchive.Infrastructure.Persistence.PostgreSql;

/// <summary>
/// Context of connection to PostgreSQL
/// </summary>
public class PostgresContext
{
    private readonly string _connectionString;

    /// <summary>
    /// Constructor of context of connection to PostgreSQL
    /// </summary>
    /// <param name="connectionString">Connection string</param>
    public PostgresContext(string connectionString)
    {
        _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    }

    /// <summary>
    /// Creates a connection to database
    /// </summary>
    /// <returns>Database connection</returns>
    public IDbConnection CreateConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}