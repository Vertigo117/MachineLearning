using ImageClassification.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ImageClassification.Services
{
    public class UploadService : IUploadService
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public UploadService(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            if (file != null)
            {
                var path = $"{webHostEnvironment.WebRootPath}\\Images\\{file.FileName}";

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                    await stream.FlushAsync();
                }

                return path;
            }
            else
            {
                throw new Exception("File is null");
            }
        }
    }
}
