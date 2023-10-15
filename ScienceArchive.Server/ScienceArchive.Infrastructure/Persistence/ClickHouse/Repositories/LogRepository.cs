using ClickHouse.Client;
using ClickHouse.Client.ADO;
using ClickHouse.Client.ADO.Parameters;
using ScienceArchive.Core.Models.Logs;
using ScienceArchive.Core.Repositories;

namespace ScienceArchive.Infrastructure.Persistence.ClickHouse.Repositories;

public class ClickHouseLogRepository : ILogRepository
{
	private readonly IClickHouseConnection _connection;
	
	public ClickHouseLogRepository(IClickHouseConnection connection)
	{
		_connection = connection ?? throw new ArgumentNullException(nameof(connection));
	}
	
	public async Task<RequestLog> LogRequest(RequestLog log)
	{
		var command = PrepareLogRequestCommand(log);
		await command.ExecuteNonQueryAsync();

		return log;
	}

	private ClickHouseCommand PrepareLogRequestCommand(RequestLog log)
	{
		var command = _connection.CreateCommand();

		command.Parameters.AddRange(new[]
		{
			new ClickHouseDbParameter
			{
				ClickHouseType = "DateTime('UTC')",
				ParameterName = "timestamp",
				Value = log.Timestamp
			},
			new ClickHouseDbParameter
			{
				ClickHouseType = "String",
				ParameterName = "ip",
				Value = log.Ip

			},
			new ClickHouseDbParameter
			{
				ClickHouseType = "String",
				ParameterName = "url",
				Value = log.Url
			},
			new ClickHouseDbParameter
			{
				ClickHouseType = "String",
				ParameterName = "user_agent",
				Value = log.UserAgent
			},
		});

		command.CommandText = @"
			INSERT INTO `request_logs`
                VALUES 
                (
                    null,
					{timestamp:DateTime('UTC')},
                    {ip:String},
                    {url:String},
                    {user_agent:String}
                )";
		
		return command;
	}
}