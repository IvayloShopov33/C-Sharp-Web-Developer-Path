
namespace MyWebServer.Controllers
{
    public class HttpGetAttribute : HttpMethodAttribute
    {
        public HttpGetAttribute() 
            : base(Http.Enums.HttpMethod.GET)
        {
        }
    }
}