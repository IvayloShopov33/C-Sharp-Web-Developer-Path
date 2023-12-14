using LogForU.Core.Enums;
using LogForU.Core.Exceptions;
using LogForU.Core.Utils;

namespace LogForU.Core.Models
{
    public class Message
    {
        private string createdTime;
        private string message;

        public Message(string createdTime, string text, ReportLevel reportLevel)
        {
            this.CreatedTime = createdTime;
            this.Text = text;
            this.ReportLevel = reportLevel;
        }

        public string CreatedTime
        {
            get
            {
                return this.createdTime;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyCreatedTimeException();
                }

                if (!DateTimeValidator.ValidateDateTimeFormat(value))
                {
                    throw new InvalidDateTimeFormatException();
                }

                this.createdTime = value;
            }
        }

        public string Text
        {
            get
            {
                return this.message;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyTextMessageException();
                }

                this.message = value;
            }
        }

        public ReportLevel ReportLevel { get; set; }
    }
}
