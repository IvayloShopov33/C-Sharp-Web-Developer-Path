namespace LogForU.Core.Exceptions
{
    public class EmptyFileNameException : Exception
    {
        private const string DefaultExceptionMessage = "File's name cannot be null or whitespace";

        public EmptyFileNameException()
            : base(DefaultExceptionMessage)
        {

        }

        public EmptyFileNameException(string message)
            : base(message)
        {

        }
    }
}
