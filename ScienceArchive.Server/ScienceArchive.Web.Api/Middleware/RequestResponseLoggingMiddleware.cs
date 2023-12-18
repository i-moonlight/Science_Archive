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
		httpContext.Request.EnableBuffering();
		
		var origBody = httpContext.Response.Body;
		await using var memoryStream = new MemoryStream();
		httpContext.Response.Body = memoryStream;
		
		await _next(httpContext);
		
		memoryStream.Seek(0, SeekOrigin.Begin);
		var responseBody = await new StreamReader(memoryStream).ReadToEndAsync();
		memoryStream.Seek(0, SeekOrigin.Begin);

		await memoryStream.CopyToAsync(origBody);
		httpContext.Response.Body = origBody;
		
		var log = await GetRequestLog(httpContext);

		log.Response = responseBody;
		
		_logger.LogInformation($"""
		                        Received request:
		                        			URL: {log.Url}
		                        			IP: {log.Ip}
		                        			User-Agent: {log.UserAgent}
		                        """);
		_logRepository.LogRequest(log);
	}

	private async Task<RequestLog> GetRequestLog(HttpContext httpContext)
	{
		var url = httpContext.Request.GetDisplayUrl();
		var userAgent = "unknown";
		var ip = "unknown";
		var requestBody = "empty";

		if (httpContext.Connection.RemoteIpAddress is not null)
		{
			ip = httpContext.Connection.RemoteIpAddress.ToString();
		}

		if (httpContext.Request.Headers.TryGetValue("User-Agent", out var realUserAgent))
		{
			userAgent = realUserAgent.FirstOrDefault()!;
		}

		if (httpContext.Request.Body.CanRead)
		{
			httpContext.Request.Body.Position = 0;
			
			using var reader = new StreamReader(httpContext.Request.Body);
			requestBody = await reader.ReadToEndAsync();
			
			if (httpContext.Request.Body.CanSeek)
			{
				httpContext.Request.Body.Seek(0, SeekOrigin.Begin);
			}
		}
		
		var requestLog = new RequestLog
		{
			Timestamp = DateTime.Now,
			Ip = ip,
			Url = url,
			UserAgent = userAgent,
			Request = requestBody
		};
		
		return requestLog;
	}
}