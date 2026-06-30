using System.Text.Json;
using FluentValidation;
using PaymentGatewayAggregator.Application.Common.Responses;

namespace PaymentGatewayAggregator.API.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            context.Response.StatusCode = 400;
            context.Response.ContentType = "application/json";

            var response = new ApiResponse<object>
            {
                Success = false,
                Message = "Validation failed.",
                Errors = ex.Errors.Select(x => x.ErrorMessage).ToList()
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";

            var response = new ApiResponse<object>
            {
                Success = false,
                Message = ex.Message
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}