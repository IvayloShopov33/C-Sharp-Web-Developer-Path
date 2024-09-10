using MyWebServer.Common;
using MyWebServer.Http;
using MyWebServer.Http.Enums;
using MyWebServer.Routing.Contracts;

namespace MyWebServer.Routing
{
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<Http.Enums.HttpMethod, Dictionary<string, Func<HttpRequest, HttpResponse>>> routes;

        public RoutingTable()
        {
            this.routes = new()
            {
                [Http.Enums.HttpMethod.GET] = new(),
                [Http.Enums.HttpMethod.POST] = new(),
                [Http.Enums.HttpMethod.PUT] = new(),
                [Http.Enums.HttpMethod.DELETE] = new(),

            };
        }

        public IRoutingTable Map(Http.Enums.HttpMethod httpMethod, string path, HttpResponse httpResponse)
        {
            Guard.AgainstNull(path, nameof(path));

            return this.Map(httpMethod, path, request => httpResponse);
        }

        public IRoutingTable Map(Http.Enums.HttpMethod httpMethod, string path, Func<HttpRequest, HttpResponse> responseFunc)
        {
            Guard.AgainstNull(path, nameof(path));
            Guard.AgainstNull(responseFunc, nameof(responseFunc));

            if (this.routes.ContainsKey(httpMethod) && this.routes[httpMethod].ContainsKey(path.ToLower()))
            {
                throw new InvalidOperationException($"Route {httpMethod.ToString().ToUpper()} {path} already exists.");
            }

            this.routes[httpMethod][path.ToLower()] = responseFunc;

            return this;
        }

        public IRoutingTable MapGet(string path, HttpResponse httpResponse)
            => this.MapGet(path, request => httpResponse);

        public IRoutingTable MapGet(string path, Func<HttpRequest, HttpResponse> responseFunc)
            => this.Map(Http.Enums.HttpMethod.GET, path, responseFunc);

        public IRoutingTable MapPost(string path, HttpResponse httpResponse)
            => this.MapPost(path, request => httpResponse);

        public IRoutingTable MapPost(string path, Func<HttpRequest, HttpResponse> responseFunc)
            => this.Map(Http.Enums.HttpMethod.POST, path, responseFunc);

        public IRoutingTable MapStaticFiles(string folder = "wwwroot")
        {
            var staticFilesFolder = Path.Combine(Directory.GetCurrentDirectory(), folder);
            if (!Directory.Exists(staticFilesFolder))
            {
                return this;
            }

            var staticFiles = Directory.GetFiles(staticFilesFolder, "*.*", SearchOption.AllDirectories);

            foreach (var file in staticFiles)
            {
                var relativePath = Path.GetRelativePath(staticFilesFolder, file);
                var urlPath = "/" + relativePath.Replace("\\", "/");

                this.MapGet(urlPath, request =>
                {
                    var content = File.ReadAllText(file);
                    var fileExtension = Path.GetExtension(file).Trim('.');
                    var contentType = HttpContentType.GetFileExtension(fileExtension);

                    return new HttpResponse(HttpStatusCode.OK).SetContent(content, contentType);
                });
            }

            return this;
        }

        public HttpResponse ExecuteRequest(HttpRequest request)
        {
            var requestMethod = request.Method;
            var requestPath = request.Path.ToLower();

            if (!this.routes.ContainsKey(requestMethod) || !this.routes[requestMethod].ContainsKey(requestPath))
            {
                return new HttpResponse(HttpStatusCode.NotFound);
            }

            var responseFunction = this.routes[requestMethod][requestPath];

            return responseFunction(request);
        }
    }
}