using System.Web;

using MyWebServer.Http.Collections;
using MyWebServer.Services;
using MyWebServer.Services.Contracts;

namespace MyWebServer.Http
{
    public class HttpRequest
    {
        private static Dictionary<string, HttpSession> Sessions = new();

        private const string NewLine = $"\r\n";

        public Enums.HttpMethod Method { get; private set; }

        public string Path { get; private set; }

        public QueryCollection Query { get; private set; }

        public HeaderCollection Headers { get; private set; }

        public CookieCollection Cookies { get; private set; }

        public HttpSession Session {  get; private set; }

        public FormCollection Form { get; private set; }

        public string Body { get; private set; }

        public IServiceCollection Services { get; private set; }

        public static HttpRequest Parse(string request, ServiceCollection services)
        {
            var lines = request.Split(NewLine);
            var startLine = lines.First().Split(" ");

            var method = ParseMethod(startLine.First());
            var url = startLine[1];
            var (path, query) = ParseUrl(url);

            var headers = ParseHeaders(lines.Skip(1));

            var cookies = ParseCookies(headers);
            var session = GetSession(cookies);

            var bodyLines = lines.Skip(headers.Count + 2).ToArray();
            var body = string.Join(NewLine, bodyLines);

            var form = ParseForm(headers, body);

            return new HttpRequest
            {
                Method = method,
                Path = path,
                Query = query,
                Headers = headers,
                Cookies = cookies,
                Session = session,
                Form = form,
                Body = body,
                Services = services,
            };
        }

        private static Enums.HttpMethod ParseMethod(string method)
        {
            return method.ToUpper() switch
            {
                "GET" => Enums.HttpMethod.GET,
                "POST" => Enums.HttpMethod.POST,
                "PUT" => Enums.HttpMethod.PUT,
                "DELETE" => Enums.HttpMethod.DELETE,
                _ => throw new InvalidOperationException($"Method {method} is not supported."),
            };
        }

        private static (string, QueryCollection) ParseUrl(string url)
        {
            var urlParts = url.Split('?', 2);

            var path = urlParts.First().ToLower();
            var query = urlParts.Length > 1
                ? ParseQuery(urlParts.Last())
                : new QueryCollection();

            return (path, query);
        }

        private static QueryCollection ParseQuery(string queryString)
        {
            var queryCollection = new QueryCollection();
            var parsedValues = ParseQueryString(queryString);

            foreach (var (name, value) in parsedValues)
            {
                queryCollection.Add(name, value);
            }

            return queryCollection;
        }

        private static HeaderCollection ParseHeaders(IEnumerable<string> headers)
        {
            var headersCollection = new HeaderCollection();

            foreach (var header in headers)
            {
                if (header == string.Empty)
                {
                    break;
                }

                var headerParts = header.Split(":", 2);

                if (headerParts.Length != 2)
                {
                    throw new InvalidOperationException("Request is not valid.");
                }

                var headerName = headerParts[0];
                var headerValue = headerParts[1];

                headersCollection.Add(headerName, headerValue);
            }

            return headersCollection;
        }

        private static CookieCollection ParseCookies(HeaderCollection headers)
        {
            var cookiesCollection = new CookieCollection();

            if (headers.ContainsKey(HttpHeader.Cookie))
            {
                var cookieHeader = headers[HttpHeader.Cookie];
                var allCookies = cookieHeader.Split(';');

                foreach (var cookie in allCookies)
                {
                    var cookieParts = cookie.Split("=", 2);

                    var cookieName = cookieParts.First().Trim();
                    var cookieValue = cookieParts.Last().Trim();

                    cookiesCollection.Add(cookieName, cookieValue);
                }
            }

            return cookiesCollection;
        }

        private static HttpSession GetSession(CookieCollection cookies)
        {
            var sessionId = cookies.ContainsKey(HttpSession.SessionCookieName)
                ? cookies[HttpSession.SessionCookieName]
                : Guid.NewGuid().ToString();

            if (!Sessions.ContainsKey(sessionId))
            {
                Sessions[sessionId] = new HttpSession(sessionId)
                {
                    IsNew = true,
                };
            }

            return Sessions[sessionId];
        }

        private static FormCollection ParseForm(HeaderCollection headers, string body)
        {
            var formCollection = new FormCollection();

            if (headers.ContainsKey(HttpHeader.ContentType) &&
                headers[HttpHeader.ContentType].Trim() == HttpContentType.FormUrlEncoded)
            {
                var parsedValues = ParseQueryString(body);

                foreach (var (name, value) in parsedValues)
                {
                    formCollection.Add(name, value);
                }
            }


            return formCollection;
        }

        private static Dictionary<string, string> ParseQueryString(string queryString)
            => HttpUtility.UrlDecode(queryString)
                   .Split("&")
                   .Select(part => part.Split("="))
                   .Where(part => part.Length == 2)
                   .ToDictionary(part => part.First().ToLower(), part => part.Last());
    }
}