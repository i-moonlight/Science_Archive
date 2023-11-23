namespace ScienceArchive.Core.Models.Logs;

public record RequestLog
{
	public DateTime Timestamp { get; set; }
	public string Ip { get; set; }
	public string Url { get; set; }
	public string UserAgent { get; set; }
	public string? Request { get; set; }
	public string? Response { get; set; }
}