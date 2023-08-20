using System.Data;
using Dapper;

namespace ScienceArchive.Infrastructure.PostgreSql.SqlMappers;

public class GenericArrayToListMapper<T> : SqlMapper.TypeHandler<List<T>>
{
	public override void SetValue(IDbDataParameter parameter, List<T> value)
	{
		parameter.Value = value;
	}

	public override List<T> Parse(object value)
	{
		var arr = (T[])value;
		return arr.ToList();
	}
}