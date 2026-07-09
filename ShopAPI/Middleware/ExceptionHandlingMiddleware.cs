using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using System.Text.Json;

namespace ShopAPI.Middleware
{
    public sealed class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(
            HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    ex.Message);

                await HandleExceptionAsync(
                    context,
                    ex);
            }
        }

        private static async Task HandleExceptionAsync(
            HttpContext context,
            Exception exception)
        {
            context.Response.ContentType =
                "application/problem+json";

            var problem = new ProblemDetails();

            switch (exception)
            {
                case ValidationException validationException:

                    context.Response.StatusCode = StatusCodes.Status400BadRequest;

                    problem.Status = 400;

                    problem.Title = "Validation Error";

                    problem.Detail = "One or more validation errors occurred.";

                    problem.Extensions["errors"] =
                        validationException.Errors
                            .Select(x => new
                            {
                                x.PropertyName,
                                x.ErrorMessage
                            });

                    break;

                case KeyNotFoundException:

                    context.Response.StatusCode = StatusCodes.Status404NotFound;

                    problem.Status = 404;

                    problem.Title = "Resource Not Found";

                    problem.Detail = exception.Message;

                    break;

                default:

                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                    problem.Status = 500;

                    problem.Title = "Server Error";

                    problem.Detail = "An unexpected error occurred.";

                    break;
            }

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(problem));
        }
    }
}
