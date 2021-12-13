using ImageClassification.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageClassification.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassificationController : ControllerBase
    {
        private readonly IUploadService uploadService;
        private readonly IClassificationService classificationService;

        public ClassificationController(IUploadService uploadService, IClassificationService classificationService)
        {
            this.uploadService = uploadService;
            this.classificationService = classificationService;
        }

        [HttpPost]
        public ActionResult Post([FromForm]IFormFile file)
        {
            string imagePath = uploadService.UploadFile(file);

            ImageClassificationModel.ModelOutput output = classificationService.GetImageClassification(imagePath);

            return Ok(output);
        }
    }
}
