public class ApiResponse<T>
{
    public bool Success { get; set; }
    public string Code { get; set; } = "OK";
    public string Message { get; set; } = "成功";
    public T Data { get; set; }

    public static ApiResponse<T> Ok(T data) =>
        new ApiResponse<T> { Success = true, Data = data };

    public static ApiResponse<T> Fail(string code, string message, int status = 400, string traceId = null) =>
        new ApiResponse<T> { Success = false, Code = code, Message = message };
}
