﻿namespace eCommerce.API.Middlewares;
public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception ex)
        {
            // Log the exception type and message
            logger.LogError("{S}: {ExMessage}", ex.GetType().ToString(), ex.Message);

            if (ex.InnerException is not null)
            {
                // Log the inner exception type and message
                logger.LogError("{S}: {InnerExceptionMessage}", ex.InnerException.GetType().ToString(), ex.InnerException.Message);
            }

            httpContext.Response.StatusCode = 500; //Internal Server Error
            await httpContext.Response.WriteAsJsonAsync(
                new { Message = ex.Message, 
                    Type = ex.GetType().ToString() 
                });
        }

    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class ExceptionHandlingMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}