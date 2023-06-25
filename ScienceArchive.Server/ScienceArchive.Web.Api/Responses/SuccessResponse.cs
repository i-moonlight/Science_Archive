namespace ScienceArchive.Web.Api.Responses;

public class SuccessResponse : Response
{
    public SuccessResponse(object data) : base(data)
    {
        Success = true;
    }
}