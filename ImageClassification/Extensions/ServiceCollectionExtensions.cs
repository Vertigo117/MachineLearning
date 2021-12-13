using ImageClassification.Interfaces;
using ImageClassification.Models;
using ImageClassification.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.ML;
using System.IO;

namespace ImageClassification.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUploadService, UploadService>();
            services.AddScoped<IClassificationService, ClassificationService>();

            AddPredictionEnginePool(services);
        }

        private static void AddPredictionEnginePool(IServiceCollection services)
        {
            string filePath = Path.GetFullPath("ImageClassificationModel.zip");

            services.AddPredictionEnginePool<Input, Output>()
                .FromFile(modelName: "ImageClassificationModel", filePath: filePath, watchForChanges: true);
        }
    }
}
