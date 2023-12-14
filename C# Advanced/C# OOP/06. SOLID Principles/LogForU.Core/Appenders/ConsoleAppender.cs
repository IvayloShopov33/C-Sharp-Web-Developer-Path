using LogForU.Core.Appenders.Interfaces;
using LogForU.Core.Enums;
using LogForU.Core.Layouts.Interfaces;
using LogForU.Core.Models;

namespace LogForU.Core.Appenders
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout, ReportLevel reportLevel = ReportLevel.Info)
        {
            this.Layout = layout;
            this.ReportLevel = reportLevel;
        }

        public ILayout Layout { get; private set; }

        public ReportLevel ReportLevel { get; set; }

        public int MessagesAppended { get; private set; }

        public void Append(Message message)
        {
            Console.WriteLine(string.Format(this.Layout.Format, message.CreatedTime, message.ReportLevel, message.Text));

            this.MessagesAppended++;
        }
    }
}
