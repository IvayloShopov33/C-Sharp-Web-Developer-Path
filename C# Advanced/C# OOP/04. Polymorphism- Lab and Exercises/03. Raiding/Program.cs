using Raiding.Core;
using Raiding.Core.Interfaces;
using Raiding.Factories;
using Raiding.Factories.Interfaces;
using Raiding.IO;
using Raiding.IO.Interfaces;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();
            IHeroFactory heroFactory = new HeroFactory();

            IEngine engine = new Engine(reader, writer, heroFactory);
            engine.Run();
        }
    }
}