using System.Text.Json;
using ScienceArchive.Web.Api.Responses;

namespace ScienceArchive.Web.Api.Middleware;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            var response = new ErrorResponse(ex.Message);
            var body = JsonSerializer.Serialize(response);

            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsync(body);
        }
    }
}
