using System.Text.Json.Serialization;

namespace ScienceArchive.Web.Api.Responses;

public abstract class Response
{
    protected Response(object? data = null)
    {
        Data = data;
    }

    /// <summary>
    /// Indicates if request was successful
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    /// <summary>
    /// Data of the response
    /// </summary>
    [JsonPropertyName("data")]
    public object? Data { get; set; }

    /// <summary>
    /// Error occured while request
    /// </summary>
    [JsonPropertyName("error")]
    public string? Error { get; set; }
}