using Operations.Core;
using Operations.Core.Interfaces;

namespace Operations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}