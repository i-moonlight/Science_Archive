using System;
namespace ScienceArchive.Api.Responses
{
    public class ErrorResponse : Response
    {
        public ErrorResponse(string errorMessage) : base()
        {
            Error = errorMessage;
        }
    }
}

