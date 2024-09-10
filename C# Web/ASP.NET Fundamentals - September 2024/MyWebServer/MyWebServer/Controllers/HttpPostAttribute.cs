
namespace MyWebServer.Controllers
{
    public class HttpPostAttribute : HttpMethodAttribute
    {
        public HttpPostAttribute() 
            : base(Http.Enums.HttpMethod.POST)
        {
        }
    }
}