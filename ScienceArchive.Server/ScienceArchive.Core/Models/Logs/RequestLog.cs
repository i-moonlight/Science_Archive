namespace ScienceArchive.Core.Models.Logs;

public record RequestLog(
	DateTime Timestamp, 
	string Ip, 
	string Url, 
	string UserAgent);