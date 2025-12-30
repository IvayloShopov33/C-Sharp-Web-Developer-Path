using LogForU.ConsoleApp.Core.Interfaces;
using LogForU.ConsoleApp.CustomLayouts;

using LogForU.Core.Appenders.Interfaces;
using LogForU.Core.Appenders;
using LogForU.Core.IO.Interfaces;
using LogForU.Core.IO;
using LogForU.Core.Layouts.Interfaces;
using LogForU.Core.Loggers.Interfaces;
using LogForU.Core.Loggers;

namespace LogForU.ConsoleApp.Core
{
    internal class Engine : IEngine
    {
        public void Run()
        {
            ILayout xmlLayout = new XmlLayout();
            IAppender consoleAppender = new ConsoleAppender(xmlLayout);

            ILogFile file = new LogFile();
            IAppender fileAppender = new FileAppender(xmlLayout, file);

            ILogger logger = new Logger(consoleAppender, fileAppender);
            logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");
        }
    }
}
