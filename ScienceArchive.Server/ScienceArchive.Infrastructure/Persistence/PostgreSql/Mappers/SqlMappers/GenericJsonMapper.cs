using System.Data;
using Dapper;
using System.Text.Json;

namespace ScienceArchive.Infrastructure.PostgreSql.SqlMappers;

public class GenericJsonMapper<T> : SqlMapper.TypeHandler<T?>
{
	public override void SetValue(IDbDataParameter parameter, T? value)
	{
		parameter.Value = JsonSerializer.Serialize(value);
	}

	public override T? Parse(object value)
	{
		if (value is string json)
		{
			return JsonSerializer.Deserialize<T>(json);
		}

		return default;
	}
}