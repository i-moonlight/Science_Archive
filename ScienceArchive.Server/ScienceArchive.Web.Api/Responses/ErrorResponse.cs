using System;
namespace ScienceArchive.Web.Api.Responses
{
    public class ErrorResponse : Response
    {
        public ErrorResponse(string errorMessage) : base()
        {
            Error = errorMessage;
        }
    }
}

