using ImageClassification.Interfaces;
using ImageClassification.Models;
using Microsoft.Extensions.ML;
using System.Threading.Tasks;

namespace ImageClassification.Services
{
    public class ClassificationService : IClassificationService
    {
        private const string MODEL_NAME = "ImageClassificationModel";

        private readonly PredictionEnginePool<Input, Output> predictionEnginePool;

        public ClassificationService(PredictionEnginePool<Input, Output> predictionEnginePool)
        {
            this.predictionEnginePool = predictionEnginePool;
        }

        public async Task<Output> GetImageClassificationAsync(string imagePath)
        {
            var input = new Input
            {
                ImageSource = imagePath
            };

            return await Task.Factory.StartNew(() => predictionEnginePool.Predict(modelName: MODEL_NAME, example: input));
        }
    }
}
