using Microsoft.AspNetCore.Http.Extensions;
using ScienceArchive.Core.Models.Logs;
using ScienceArchive.Core.Repositories;

namespace ScienceArchive.Web.Api.Middleware;

public class RequestResponseLoggingMiddleware
{
	private readonly RequestDelegate _next;
	private readonly ILogger<ExceptionHandlerMiddleware> _logger;
	private readonly ILogRepository _logRepository;

	public RequestResponseLoggingMiddleware(
		RequestDelegate next, 
		ILogger<ExceptionHandlerMiddleware> logger,
		ILogRepository logRepository)
	{
		_next = next;
		_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		_logRepository = logRepository ?? throw new ArgumentNullException(nameof(logRepository));
	}
	
	public async Task Invoke(HttpContext httpContext)
	{
		var log = GetRequestLog(httpContext);
		_logger.LogInformation($"""
		                        Received request:
		                        			URL: {log.Url}
		                        			IP: {log.Ip}
		                        			User-Agent: {log.UserAgent}
		                        """);
		_logRepository.LogRequest(log);
		
		await _next(httpContext);
	}

	private RequestLog GetRequestLog(HttpContext httpContext)
	{
		var url = httpContext.Request.GetDisplayUrl();
		var userAgent = "unknown";
		var ip = "unknown";

		if (httpContext.Request.Headers.TryGetValue("X-Forwarded-For", out var realIp))
		{
			ip = realIp.FirstOrDefault()!;
		}

		if (httpContext.Request.Headers.TryGetValue("User-Agent", out var realUserAgent))
		{
			userAgent = realUserAgent.FirstOrDefault()!;
		}
		
		var requestLog = new RequestLog(DateTime.Now, ip, url, userAgent);
		return requestLog;
	}
}