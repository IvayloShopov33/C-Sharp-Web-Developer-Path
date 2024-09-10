
namespace MyWebServer.Controllers
{
    [AttributeUsage(AttributeTargets.Method)]
    public abstract class HttpMethodAttribute : Attribute
    {
        protected HttpMethodAttribute(Http.Enums.HttpMethod httpMethod)
        {
            this.HttpMethod = httpMethod;
        }

        public Http.Enums.HttpMethod HttpMethod { get; }
    }
}