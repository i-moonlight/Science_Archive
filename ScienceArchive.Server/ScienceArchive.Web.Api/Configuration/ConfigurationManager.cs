using ScienceArchive.Application.Options;
using ScienceArchive.Infrastructure.Persistence.Options;

namespace ScienceArchive.Web.Api.Configuration;

public static class ConfigurationManager
{
	/// <summary>
	/// Get connection options
	/// </summary>
	/// <param name="builder">Instance of <see cref="WebApplicationBuilder"/></param>
	/// <returns>Connection options</returns>
	public static ConnectionOptions GetConnectionOptions(WebApplicationBuilder builder)
	{
		string dbConnectionString;

		if (builder.Environment.IsDevelopment())
		{
			dbConnectionString =
				builder.Configuration.GetConnectionString("PostgreSQL") ??
				throw new NullReferenceException("Cannot get DB connection string from config file!");
		}
		else
		{
			dbConnectionString =
				Environment.GetEnvironmentVariable("POSTGRESQL_CONNECTION_STRING") ??
				throw new NullReferenceException("Cannot get DB connection string from environment!");
		}

		if (dbConnectionString is null)
		{
			throw new NullReferenceException("Cannot get connection string!");
		}

		return new ConnectionOptions()
		{
			PostgresConnectionString = dbConnectionString,
		};
	}

	/// <summary>
	/// Get application options
	/// </summary>
	/// <param name="builder">Instance of <see cref="WebApplicationBuilder"/></param>
	/// <returns>Applications options</returns>
	public static ApplicationOptions GetApplicationOptions(WebApplicationBuilder builder)
	{
		return builder.Configuration
			       .GetSection(ApplicationOptions.OptionsName)
			       .Get<ApplicationOptions>() 
		       ?? throw new NullReferenceException("Cannot load application options");
	}
}