using ImageClassification.Models;
using System.Threading.Tasks;
using static ImageClassification.ImageClassificationModel;

namespace ImageClassification.Interfaces
{
    public interface IClassificationService
    {
        Task<Output> ClassifyImageAsync(string imagePath);
    }
}
