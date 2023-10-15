using ScienceArchive.Core.Models.Logs;

namespace ScienceArchive.Core.Repositories;

public interface ILogRepository
{
	Task<RequestLog> LogRequest(RequestLog log);
}