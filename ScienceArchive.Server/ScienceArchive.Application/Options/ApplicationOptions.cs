namespace ScienceArchive.Application.Options;

/// <summary>
/// Helper options for application layer
/// </summary>
public class ApplicationOptions
{
	/// <summary>
	/// Name of configuration field of application options
	/// </summary>
	public const string OptionsName = "ApplicationOptions";
	
	/// <summary>
	/// ID of administrator role
	/// </summary>
	public required string AdminRoleId { get; set; }
}