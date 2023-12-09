using VehiclesExtension.Core;
using VehiclesExtension.Core.Interfaces;

namespace VehiclesExtension
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