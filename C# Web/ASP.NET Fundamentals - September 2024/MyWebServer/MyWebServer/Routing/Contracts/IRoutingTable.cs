using MyWebServer.Http;

namespace MyWebServer.Routing.Contracts
{
    public interface IRoutingTable
    {
        IRoutingTable Map(Http.Enums.HttpMethod httpMethod, string path, HttpResponse httpResponse);

        IRoutingTable Map(Http.Enums.HttpMethod httpMethod, string path, Func<HttpRequest, HttpResponse> responseFunc);

        IRoutingTable MapGet(string path, HttpResponse httpResponse);

        IRoutingTable MapGet(string path, Func<HttpRequest, HttpResponse> responseFunc);

        IRoutingTable MapPost(string path, HttpResponse httpResponse);

        IRoutingTable MapPost(string path, Func<HttpRequest, HttpResponse> responseFunc);

        IRoutingTable MapStaticFiles(string folder = "wwwroot");

        HttpResponse ExecuteRequest(HttpRequest request);
    }
}