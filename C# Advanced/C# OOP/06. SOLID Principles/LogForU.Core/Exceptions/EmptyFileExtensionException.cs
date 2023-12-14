namespace LogForU.Core.Exceptions
{
    public class EmptyFileExtensionException : Exception
    {
        private const string DefaultExceptionMessage = "File's extension cannot be null or whitespace";

        public EmptyFileExtensionException()
            : base(DefaultExceptionMessage)
        {

        }

        public EmptyFileExtensionException(string message)
            : base(message)
        {

        }
    }
}
