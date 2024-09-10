using MyWebServer.App.Data.Models;

namespace MyWebServer.App.Data.Contracts
{
    public interface IData
    {
        IEnumerable<Cat> Cats { get; }
    }
}