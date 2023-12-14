namespace LogForU.Core.Exceptions
{
    public class InvalidPathException : Exception
    {
        private const string DefaultExceptionMessage = "Invalid file's path";

        public InvalidPathException()
            : base(DefaultExceptionMessage)
        {

        }

        public InvalidPathException(string message)
            : base(message)
        {

        }
    }
}
