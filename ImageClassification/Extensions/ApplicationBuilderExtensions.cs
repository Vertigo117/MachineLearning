using ImageClassification.ErrorHandling;
using Microsoft.AspNetCore.Builder;

namespace ImageClassification.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseCustomErrorHandling(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<ErrorHandlingMiddlware>();
        }
    }
}
