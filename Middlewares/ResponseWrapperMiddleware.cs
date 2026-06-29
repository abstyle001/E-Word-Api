using System.Diagnostics;
using System.Text.Json;

public class ResponseWrapperMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ResponseWrapperMiddleware> _logger;

    public ResponseWrapperMiddleware(RequestDelegate next, ILogger<ResponseWrapperMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.StartsWithSegments("/statics"))
        {
            await _next(context);
            return;
        }

        // 先替换响应流，捕获后续中间件/控制器写入的内容
        var originalBodyStream = context.Response.Body;
        await using var memStream = new MemoryStream();
        context.Response.Body = memStream;

        await _next(context);

        // 如果已经是错误状态码或已写入非 200 系列，直接把原始内容返回（异常中间件会处理）
        if (context.Response.StatusCode >= 400)
        {
            memStream.Position = 0;
            await memStream.CopyToAsync(originalBodyStream);
            context.Response.Body = originalBodyStream;
            return;
        }

        // 读取控制器写入的内容
        memStream.Position = 0;
        var bodyText = await new StreamReader(memStream).ReadToEndAsync();
        object originalObj = null;

        // 先根据 Content-Type 决定是否尝试 JSON 解析
        var contentType = context.Response.ContentType ?? string.Empty;
        var isJsonResponse = contentType.Contains("application/json", StringComparison.OrdinalIgnoreCase)
                             || contentType.Contains("+json", StringComparison.OrdinalIgnoreCase);
        if (isJsonResponse && !string.IsNullOrWhiteSpace(bodyText))
        {
            try
            {
                originalObj = JsonSerializer.Deserialize<object>(bodyText, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            catch (Exception ex)
            {
                // 解析失败，说明 bodyText 虽然标记为 JSON，但不是合法 JSON（或是文本）
                _logger.LogDebug(ex, "Response body marked as JSON but cannot deserialize; treat as raw string");
                originalObj = bodyText; // 退回为原始字符串
            }
        }
        else
        {
            // 非 JSON 响应（例如 text/plain、text/html、文件流等），直接把原始内容当作字符串处理或跳过包装
            originalObj = bodyText;
        }

        // 如果已经是 ApiResponse 格式，则直接返回原始内容
        if (originalObj is JsonElement je && je.ValueKind == JsonValueKind.Object &&
            je.TryGetProperty("success", out _))
        {
            memStream.Position = 0;
            await memStream.CopyToAsync(originalBodyStream);
            context.Response.Body = originalBodyStream;
            return;
        }

        // 否则包装为 ApiResponse
        var traceId = Activity.Current?.Id ?? context.TraceIdentifier;
        var wrapped = new ApiResponse<object>
        {
            Success = true,
            Code = "OK",
            Message = "成功",
            Data = originalObj
        };

        context.Response.ContentType = "application/json";
        context.Response.Body = originalBodyStream;
        await context.Response.WriteAsJsonAsync(wrapped);
    }
}