using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ImageClassification.ErrorHandling
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
                await HandleExceptionAsync(exception, context);
            }
        }

        private async Task HandleExceptionAsync(Exception exception, HttpContext context)
        {
            var statusCode = (int)HttpStatusCode.InternalServerError;
            var error = new Error { Message = exception.Message, StatusCode = statusCode };
            
            string json = JsonConvert.SerializeObject(error);

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(json);
        }
    }
}
