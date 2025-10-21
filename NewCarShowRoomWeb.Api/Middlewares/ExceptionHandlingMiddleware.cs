using System.Net;
using System.Text.Json;
using CoreLayer.Exception;

namespace NewCarShowRoomWeb.Api.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (UnauthorizedAccessException ex)
        {
            _logger.LogWarning(ex, "Unauthorized access attempt.");
            await HandleAsync(context, HttpStatusCode.Forbidden, ex.Message);
        }
        catch (EntityNotFoundException ex)
        {
            _logger.LogInformation(ex, "Entity not found.");
            await HandleAsync(context, HttpStatusCode.NotFound, ex.Message);
        }
        catch (DuplicateException ex)
        {
            _logger.LogWarning(ex, "Duplicate entity detected.");
            await HandleAsync(context, HttpStatusCode.Conflict, ex.Message);
        }
        catch (BusinessRuleViolationException ex)
        {
            _logger.LogWarning(ex, "Business rule violation.");
            await HandleAsync(context, HttpStatusCode.BadRequest, ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception occurred.");
            await HandleAsync(context, HttpStatusCode.InternalServerError,
                "An unexpected error occurred. Please try again later.");
        }
    }

    private static async Task HandleAsync(HttpContext ctx, HttpStatusCode code, string message)
    {
        ctx.Response.ContentType = "application/json";
        ctx.Response.StatusCode = (int)code;

        var response = new
        {
            statusCode = (int)code,
            error = message,
            timestamp = DateTime.UtcNow
        };

        var payload = JsonSerializer.Serialize(response, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        await ctx.Response.WriteAsync(payload);
    }
}
