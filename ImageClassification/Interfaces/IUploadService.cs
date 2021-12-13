using Microsoft.AspNetCore.Http;

namespace ImageClassification.Interfaces
{
    public interface IUploadService
    {
        string UploadFile(IFormFile file);
    }
}
