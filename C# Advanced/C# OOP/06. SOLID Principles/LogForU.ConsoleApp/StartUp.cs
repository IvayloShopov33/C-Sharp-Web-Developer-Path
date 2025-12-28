using LogForU.ConsoleApp.Core;
using LogForU.ConsoleApp.Core.Interfaces;
using LogForU.ConsoleApp.CustomLayouts;

using LogForU.Core.Appenders;
using LogForU.Core.Appenders.Interfaces;
using LogForU.Core.IO;
using LogForU.Core.IO.Interfaces;
using LogForU.Core.Layouts;

namespace LogForU.ConsoleApp
{
    public class StartUp
    {
        static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
