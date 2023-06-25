﻿namespace ScienceArchive.Web.Api.Responses;

public abstract class Response
{
    protected Response(object? data = null)
    {
        Data = data;
    }

    /// <summary>
    /// Indicates if request was successful
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Data of the response
    /// </summary>
    public object? Data { get; set; }

    /// <summary>
    /// Error occured while request
    /// </summary>
    public string? Error { get; set; }
}