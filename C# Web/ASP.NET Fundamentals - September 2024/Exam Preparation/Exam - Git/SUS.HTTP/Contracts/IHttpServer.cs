using System.Threading.Tasks;

namespace SUS.HTTP.Contracts
{
    public interface IHttpServer
    {
        Task StartAsync(int port);
    }
}
