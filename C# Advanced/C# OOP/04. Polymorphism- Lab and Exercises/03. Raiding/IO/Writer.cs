using Raiding.IO.Interfaces;

namespace Raiding.IO
{
    public class Writer : IWriter
    {
        public void WriteLine(string message) => Console.WriteLine(message);
    }
}
