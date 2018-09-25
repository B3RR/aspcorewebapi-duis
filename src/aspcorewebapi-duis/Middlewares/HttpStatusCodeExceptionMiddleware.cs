using System;
using System.Threading.Tasks;
using aspcorewebapi_duis.Exceptions;
using Microsoft.AspNetCore.Http;

namespace aspcorewebapi_duis.Middlewares
{
    public class HttpStatusCodeExceptionMiddleware
    {
        private readonly RequestDelegate _next;


        public HttpStatusCodeExceptionMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
                if (context.Response.StatusCode == 404)
                {
                    var url = context.Request.Host.Value + context.Request.Path;
                    await context.Response.WriteAsync("404 Page not found - " + url);
                }
            }
            catch (HttpStatusCodeException ex)
            {
                context.Response.Clear();
                context.Response.StatusCode = ex.StatusCode;
                context.Response.ContentType = ex.ContentType;
                await context.Response.WriteAsync($"{ex.StatusCode} {ex.Message}");
                return;
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync($"500 Server error - {ex.Message}");
            }
        }
    }

}