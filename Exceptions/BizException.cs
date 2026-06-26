
public class BizException : Exception
{
    public int StatusCode { get; }
    public string ErrorCode { get; }
    public BizException(string message, string errorCode = "BUSINESS_ERROR", int statusCode = 400)
        : base(message)
    {
        ErrorCode = errorCode;
        StatusCode = statusCode;
    }
}