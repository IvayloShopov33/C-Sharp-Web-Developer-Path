namespace LogForU.Core.Exceptions
{
    public class InvalidDateTimeFormatException : Exception
    {
        private const string DefaultExceptionMessage = "Invalid DateTime format";

        public InvalidDateTimeFormatException()
            : base(DefaultExceptionMessage)
        {

        }

        public InvalidDateTimeFormatException(string message)
            : base(message)
        {

        }
    }
}
