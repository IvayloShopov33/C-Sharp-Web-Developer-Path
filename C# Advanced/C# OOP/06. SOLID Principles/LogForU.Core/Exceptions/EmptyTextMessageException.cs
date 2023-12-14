namespace LogForU.Core.Exceptions
{
    public class EmptyTextMessageException : Exception
    {
        private const string DefaultExceptionMessage = "Message cannot be null or whitespace";

        public EmptyTextMessageException()
            : base(DefaultExceptionMessage)
        {

        }

        public EmptyTextMessageException(string message)
            : base(message)
        {

        }
    }
}
