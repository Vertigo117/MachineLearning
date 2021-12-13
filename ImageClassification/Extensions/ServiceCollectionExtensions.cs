using ImageClassification.Interfaces;
using ImageClassification.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ImageClassification.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUploadService, UploadService>();
            services.AddScoped<IClassificationService, ClassificationService>();
        }
    }
}
