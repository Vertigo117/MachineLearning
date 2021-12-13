using ImageClassification.ErrorHandling;
using ImageClassification.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static ImageClassification.ImageClassificationModel;

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
        [ProducesResponseType(typeof(ModelOutput), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.InternalServerError)]
        public ActionResult Post([FromForm]IFormFile file)
        {
            string imagePath = uploadService.UploadFile(file);

            ModelOutput output = classificationService.GetImageClassification(imagePath);

            return Ok(output);
        }
    }
}
