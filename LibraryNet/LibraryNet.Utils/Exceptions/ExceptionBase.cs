namespace LibraryNet.Utils.Exceptions
{
    public class ExceptionBase : Exception
    {
        public ExceptionBase() { }
        public ExceptionBase(string message) : base(message) { }
        public ExceptionBase(string message, Exception internalException) : base(message, internalException) { }
    }
}