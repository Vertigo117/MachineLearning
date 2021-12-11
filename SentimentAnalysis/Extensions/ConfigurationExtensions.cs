using Microsoft.AspNetCore.Builder;
using SentimentAnalysis.ErrorHandling;

namespace SentimentAnalysis.Extensions
{
    public static class ConfigurationExtensions
    {
        public static void UseCustomErrorHandling(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<ErrorHandlingMiddlware>();
        }
    }
}
