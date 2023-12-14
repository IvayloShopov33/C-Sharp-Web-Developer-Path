namespace LogForU.Core.Exceptions
{
    public class EmptyCreatedTimeException : Exception
    {
        private const string DefaultExceptionMessage = "Created time of message cannot be null or whitespace";

        public EmptyCreatedTimeException()
            : base(DefaultExceptionMessage)
        {

        }

        public EmptyCreatedTimeException(string message)
            : base(message)
        {

        }
    }
}
