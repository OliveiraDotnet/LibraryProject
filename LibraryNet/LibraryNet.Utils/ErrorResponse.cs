namespace LibraryNet.Utils
{
    public class ErrorResponse
    {
        public ErrorResponse()
        {
        }
        public ErrorResponse(string message)
        {
            Message = message;
        }
        public ErrorResponse(string errorCode, string message) : this(message)
        {
            ErrorCode = errorCode;
        }

        public string Message { get; set; }
        public string ErrorCode { get; set; }
    }
}