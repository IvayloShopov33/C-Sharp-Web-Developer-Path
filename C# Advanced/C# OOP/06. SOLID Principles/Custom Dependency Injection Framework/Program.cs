using LogForU.Core.Appenders;
using LogForU.Core.Appenders.Interfaces;
using LogForU.Core.Enums;
using LogForU.Core.Layouts;
using LogForU.Core.Layouts.Interfaces;
using LogForU.Core.Models;

namespace Dependency_Injection_Framework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection collection = new ServiceCollection();

            collection.AddSingleton<IAppender, ConsoleAppender>();
            collection.AddSingleton<ILayout, SimpleLayout>();
            collection.AddSingleton<string, string>();
            collection.AddSingleton<ReportLevel>((IServiceProvider sp) => ReportLevel.Error);
            collection.AddSingleton<Message>((IServiceProvider) =>
            {
                return new Message("3/31/2015 5:33:07 PM", "Error parsing request", ReportLevel.Error);
            });

            IServiceProvider provider = collection.BuildServiceProvider();

            IAppender appender = provider.GetRequiredService<IAppender>();
            appender.Append(provider.GetRequiredService<Message>());
        }
    }
}
