using System.Text.Json;
using ScienceArchive.Web.Api.Responses;

namespace ScienceArchive.Web.Api.Middleware;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await ProcessException(ex, httpContext);
        }
    }

    private async Task ProcessException(Exception ex, HttpContext httpContext)
    {
        _logger.LogError(ex.Message  + "\n" + ex.StackTrace);
        
        var response = new ErrorResponse(ex.Message);
        var body = JsonSerializer.Serialize(response);

        httpContext.Response.ContentType = "application/json";
        await httpContext.Response.WriteAsync(body);
    }
}
