using ImageClassification.Interfaces;

namespace ImageClassification.Services
{
    public class ClassificationService : IClassificationService
    {
        public ImageClassificationModel.ModelOutput GetImageClassification(string imagePath)
        {
            var input = new ImageClassificationModel.ModelInput
            {
                ImageSource = imagePath
            };

            return  ImageClassificationModel.Predict(input);
        }
    }
}
