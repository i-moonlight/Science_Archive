namespace ScienceArchive.Web.Api.Utils;

public static class HttpContextExtensions
{
	/// <summary>
	/// Get user ID from authorization token
	/// </summary>
	/// <param name="context">Instance of <see cref="HttpContext"/></param>
	/// <returns>User ID, if it found, otherwise, null</returns>
	public static string? GetUserIdFromToken(this HttpContext context)
	{
		return context.User.FindFirst("UserId")?.Value;
	}
}