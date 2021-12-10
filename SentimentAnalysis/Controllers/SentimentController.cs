using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace SentimentAnalysis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SentimentController : ControllerBase
    {
        /// <summary>
        /// Проанализировать тональность отзыва
        /// </summary>
        /// <param name="inputText">Текст отзыва</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(SentimentAnalysisModel.ModelOutput), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public ActionResult Get(string inputText)
        {
            var input = new SentimentAnalysisModel.ModelInput
            {
                Review = inputText
            };

            try
            {
                var prediction = SentimentAnalysisModel.Predict(input);

                return Ok(prediction);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
