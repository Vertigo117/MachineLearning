using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SentimentAnalysis.ErrorHandling;
using System;
using System.Net;

namespace SentimentAnalysis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SentimentController : ControllerBase
    {
        /// <summary>
        /// Проанализировать тональность текста
        /// </summary>
        /// <param name="inputText">Текст для анализа</param>
        /// <returns></returns>
        /// <response code = "200">Получить результат</response>
        /// <response code = "400">Передана пустая строка</response>
        /// <response code = "500">Произошла внутренняя ошибка сервера</response>
        [HttpGet("{inputText}")]
        [ProducesResponseType(typeof(SentimentAnalysisModel.ModelOutput), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.InternalServerError)]
        public ActionResult PredictReviewSentiment([FromRoute] string inputText)
        {
            if (string.IsNullOrEmpty(inputText))
            {
                return BadRequest("Input text is null or empty");
            }

            var input = new SentimentAnalysisModel.ModelInput
            {
                Review = inputText
            };

            var prediction = SentimentAnalysisModel.Predict(input);

            return Ok(prediction);
        }
    }
}
