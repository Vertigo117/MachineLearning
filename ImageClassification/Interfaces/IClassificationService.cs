using static ImageClassification.ImageClassificationModel;

namespace ImageClassification.Interfaces
{
    public interface IClassificationService
    {
        ModelOutput GetImageClassification(string imagePath);
    }
}
