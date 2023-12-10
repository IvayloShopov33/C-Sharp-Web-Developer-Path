using WildFarm.IO.Interfaces;

namespace WildFarm.IO
{
    public class Writer : IWriter
    {
        public void WriteLine(string message) => Console.WriteLine(message);
    }
}
