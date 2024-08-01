namespace LibraryNet.Utils
{
    public class ErrorResponseWithDeatail : ErrorResponse
    {
        public ErrorResponseWithDeatail()
        {
        }
        public ErrorResponseWithDeatail(string message) : base(message)
        {
        }
        public ErrorResponseWithDeatail(string errorCode, string message) : base(errorCode, message)
        {
        }
        public ErrorResponseWithDeatail(string errorCode, string message, params ErrorResponse[] additionalDetails) : base(errorCode, message)
        {
            AdditionalDetails = new List<ErrorResponse>(additionalDetails);
        }

        public List<ErrorResponse> AdditionalDetails { get; set; }
    }
}