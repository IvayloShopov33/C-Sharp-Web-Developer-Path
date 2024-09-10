using MyWebServer.Http;

namespace MyWebServer.Results
{
    public class UnauthorizedResult : ActionResult
    {
        public UnauthorizedResult(HttpResponse response) 
            : base(response)
        {
            this.StatusCode = Http.Enums.HttpStatusCode.Unauthorized;
        }
    }
}