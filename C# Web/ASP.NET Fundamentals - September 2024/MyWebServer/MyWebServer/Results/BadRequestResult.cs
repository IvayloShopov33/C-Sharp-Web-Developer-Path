using MyWebServer.Http;
using MyWebServer.Http.Enums;

namespace MyWebServer.Results
{
    public class BadRequestResult : HttpResponse
    {
        public BadRequestResult() 
            : base(HttpStatusCode.BadRequest)
        {
        }
    }
}