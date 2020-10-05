namespace ComparisonTech.API.Result
{
    public class ErrorMessage
    {
        public ErrorMessage(string code, string message)
        {
            ErrorCode = code;
            Message = message;
        }
        public string ErrorCode { get; }
        public string Message { get; }
    }
}
