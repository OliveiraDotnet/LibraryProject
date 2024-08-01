namespace LibraryNet.Utils.Extensions
{
    public static class ExceptionExtension
    {
        public static ErrorResponse ParaErroResposta(this Exception ex, string errorCode = "400") => new ErrorResponse(errorCode, ex.Message);
    }
}