using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SentimentAnalysis.ErrorHandling
{
    public class ErrorHandlingMiddlware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddlware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next?.Invoke(context);
            }
            catch (Exception exception)
            {
                await HandleErrorAsync(context, exception);
            }
        }

        public async Task HandleErrorAsync(HttpContext context, Exception exception)
        {

            var error = new Error
            {
                Message = $"Произошла непредвиденная ошибка: {exception.Message}", 
                StatusCode = (int)HttpStatusCode.InternalServerError
            };

            string json = JsonConvert.SerializeObject(error);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            
            await context.Response.WriteAsync(json);
        }
    }
}
