using MyWebServer.Http;
using MyWebServer.Http.Enums;

namespace MyWebServer.Results
{
    internal class NotFoundResult : ActionResult
    {
        public NotFoundResult(HttpResponse response) 
            : base(response)
        {
            this.StatusCode = HttpStatusCode.NotFound;
        }
    }
}