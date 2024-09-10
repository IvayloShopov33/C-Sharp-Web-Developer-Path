using MyWebServer.Http;
using MyWebServer.Http.Enums;

namespace MyWebServer.Results
{
    public class RedirectResult : ActionResult
    {
        public RedirectResult(HttpResponse response, string location) 
            : base(response)
        {
            this.StatusCode = HttpStatusCode.Found;
            this.Headers.Add(HttpHeader.Location, location);
        }
    }
}