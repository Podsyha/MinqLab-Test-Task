using System.Net;
using System.Text.Json;

namespace MonqLab_test_task.Common.Middlewares;

/// <summary>
/// Обработчик ошибок
/// </summary>
public sealed class ExceptionMiddleware
{
    public ExceptionMiddleware(RequestDelegate nextRequestDelegate)
    {
        _nextRequestDelegate = nextRequestDelegate;
    }

    private readonly RequestDelegate _nextRequestDelegate;


    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _nextRequestDelegate(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            response.StatusCode = error switch
            {
                NullReferenceException => (int)HttpStatusCode.NotFound,
                UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
                DirectoryNotFoundException => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.BadRequest
            };

            string result = JsonSerializer.Serialize(error.Message);
            await response.WriteAsync(result);
        }
    }
}