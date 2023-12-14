using LogForU.Core.Appenders.Interfaces;
using LogForU.Core.Enums;
using LogForU.Core.IO.Interfaces;
using LogForU.Core.Layouts.Interfaces;
using LogForU.Core.Models;

namespace LogForU.Core.Appenders
{
    public class FileAppender : IAppender
    {
        public FileAppender(ILayout layout, ILogFile logFile, ReportLevel reportLevel = ReportLevel.Info)
        {
            this.Layout = layout;
            this.LogFile = logFile;
            this.ReportLevel = reportLevel;
        }

        public ILayout Layout { get; private set; }

        public ILogFile LogFile { get; private set; }

        public ReportLevel ReportLevel { get; set; }

        public int MessagesAppended { get; private set; }

        public void Append(Message message)
        {
            string content = string.Format(this.Layout.Format, message.CreatedTime, message.ReportLevel, message.Text) + Environment.NewLine;

            File.AppendAllText(this.LogFile.FullPath, content);
            this.MessagesAppended++;
        }
    }
}
