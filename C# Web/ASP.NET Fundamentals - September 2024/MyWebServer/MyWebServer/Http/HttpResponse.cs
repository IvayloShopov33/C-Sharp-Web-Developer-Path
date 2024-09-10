using System.Text;

using MyWebServer.Common;
using MyWebServer.Http.Collections;
using MyWebServer.Http.Enums;

namespace MyWebServer.Http
{
    public class HttpResponse
    {
        public HttpResponse(HttpStatusCode statusCode)
        {
            this.StatusCode = statusCode;

            this.Headers.Add(HttpHeader.Server, "My Web Server");
            this.Headers.Add(HttpHeader.Date, $"{DateTime.UtcNow.ToString("r")}");
        }

        public HttpStatusCode StatusCode { get; protected set; }

        public HeaderCollection Headers { get; } = new HeaderCollection();

        public CookieCollection Cookies { get; } = new CookieCollection();

        public string Content { get; protected set; }

        public static HttpResponse ForError(string message)
            => new HttpResponse(HttpStatusCode.InternalServerError)
                .SetContent(message, HttpContentType.PlainText);

        public HttpResponse SetContent(string content, string contentType)
        {
            Guard.AgainstNull(content, nameof(content));
            Guard.AgainstNull(contentType, nameof(contentType));

            var contentLength = Encoding.UTF8.GetByteCount(content).ToString();

            this.Headers.Add(HttpHeader.ContentType, contentType);
            this.Headers.Add(HttpHeader.ContentLength, contentLength);

            this.Content = content;

            return this;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"HTTP/1.1 {(int)this.StatusCode} {this.StatusCode}");

            foreach (var header in this.Headers)
            {
                result.AppendLine(header.ToString());
            }

            foreach (var cookie in this.Cookies)
            {
                result.AppendLine($"{HttpHeader.SetCookie}: {cookie}");
            }

            if (!string.IsNullOrEmpty(this.Content))
            {
                result.AppendLine();
                result.AppendLine(this.Content);
            }

            return result.ToString().TrimEnd();
        }
    }
}