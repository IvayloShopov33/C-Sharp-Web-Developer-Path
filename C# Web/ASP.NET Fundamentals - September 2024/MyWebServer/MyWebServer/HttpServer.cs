using System.Net;
using System.Net.Sockets;
using System.Text;

using MyWebServer.Http;
using MyWebServer.Routing;
using MyWebServer.Routing.Contracts;
using MyWebServer.Services;
using MyWebServer.Services.Contracts;

namespace MyWebServer
{
    public class HttpServer
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener listener;
        private readonly IRoutingTable routingTable;
        private readonly ServiceCollection services;

        private HttpServer(string ipAddress, int port, IRoutingTable routingTable)
        {
            this.ipAddress = IPAddress.Parse(ipAddress);
            this.port = port;

            this.listener = new TcpListener(this.ipAddress, this.port);

            this.routingTable = routingTable;

            this.services = new ServiceCollection();
        }

        private HttpServer(int port, IRoutingTable routingTable)
            : this("127.0.0.1", port, routingTable)
        {

        }

        private HttpServer(IRoutingTable routingTable)
            : this(9090, routingTable)
        {

        }

        public static HttpServer WithRoutes(Action<IRoutingTable> routingTableConfiguration)
        {
            var routingTable = new RoutingTable();
            routingTableConfiguration(routingTable);

            var httpServer = new HttpServer(routingTable);

            return httpServer;
        }

        public HttpServer WithServices(Action<IServiceCollection> serviceCollectionConfiguration) 
        {
            serviceCollectionConfiguration(this.services);

            return this;
        }

        public HttpServer WithConfiguration<TService>(Action<TService> configuration)
            where TService : class
        {
            var service = this.services.GetService<TService>();
            if (service == null)
            {
                throw new InvalidOperationException($"Service '{typeof(TService).FullName}' is not registered.");
            }

            configuration(service);

            return this;
        }

        public async Task Start()
        {
            this.listener.Start();
            Console.WriteLine($"Server started on port {this.port}...");
            Console.WriteLine("Listening for requests...");

            while (true)
            {
                var connection = await this.listener.AcceptTcpClientAsync();

                _ = Task.Run(async () =>
                {
                    var networkStream = connection.GetStream();

                    var requestText = await ReadRequest(networkStream);
                    Console.WriteLine(requestText);

                    try
                    {
                        var request = HttpRequest.Parse(requestText, this.services);
                        var response = this.routingTable.ExecuteRequest(request);

                        this.PrepareSession(request, response);

                        this.LogPipeLine(requestText, response.ToString());

                        await WriteResponse(networkStream, response);
                    }
                    catch (Exception e)
                    {
                        var errorResponse = HttpResponse.ForError($"{e.Message}{Environment.NewLine}{e.StackTrace}");

                        await WriteResponse(networkStream, errorResponse);

                    }

                    connection.Close();
                });
            }
        }

        private async Task<string> ReadRequest(NetworkStream networkStream)
        {
            var totalBytesRead = 0;
            var bufferLength = 1024;
            var buffer = new byte[bufferLength];
            var requestBuilder = new StringBuilder();

            do
            {
                var bytesRead = await networkStream.ReadAsync(buffer, 0, bufferLength);
                totalBytesRead += bytesRead;

                if (totalBytesRead > 10 * bufferLength)
                {
                    throw new InvalidOperationException("Request is too large.");
                }

                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            }
            while (networkStream.DataAvailable);

            return requestBuilder.ToString().TrimEnd();
        }

        private void PrepareSession(HttpRequest request, HttpResponse response)
        {
            if (request.Session.IsNew)
            {
                response.Cookies.Add(HttpSession.SessionCookieName, request.Session.Id);
                request.Session.IsNew = false;
            }
        }

        private void LogPipeLine(string request, string response)
        {
            var separator = new string('-', 50);
            var log = new StringBuilder();

            log.AppendLine();
            log.AppendLine(separator);

            log.AppendLine("Request: ");
            log.AppendLine(request);

            log.AppendLine();

            log.AppendLine("Response: ");
            log.AppendLine(response);

            log.AppendLine();

            Console.WriteLine(log.ToString());
        }

        private async Task WriteResponse(NetworkStream networkStream, HttpResponse response)
        {
            var responseBytes = Encoding.UTF8.GetBytes(response.ToString());

            await networkStream.WriteAsync(responseBytes);
        }
    }
}