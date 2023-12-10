using WildFarm.IO.Interfaces;

namespace WildFarm.IO
{
    internal class Reader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
