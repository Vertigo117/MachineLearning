using ImageClassification.ErrorHandling;
using ImageClassification.Interfaces;
using ImageClassification.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

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

        /// <summary>
        /// Загрузить и проанализировать картинку
        /// </summary>
        /// <param name="file">Картинка</param>
        /// <returns>Классификация картинки</returns>
        /// <response code="200">Успешный результат</response>
        /// <response code="500">Внутренняя ошибка сервера</response>
        [HttpPost]
        [ProducesResponseType(typeof(Input), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> Post([FromForm]IFormFile file)
        {
            string imagePath = await uploadService.UploadFileAsync(file);

            Output output = await classificationService.GetImageClassificationAsync(imagePath);

            return Ok(output);
        }
    }
}
