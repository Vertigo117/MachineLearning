using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ImageClassification.Interfaces
{
    public interface IUploadService
    {
        Task<string> UploadFileAsync(IFormFile file);
    }
}
