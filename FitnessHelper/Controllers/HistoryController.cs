using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TGolla.Swashbuckle.AspNetCore.SwaggerGen;

namespace FitnessHelper.Controllers
{
    [Route("api/history")]
    [SwaggerControllerOrder(7)]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        [HttpPost("/training")]
        public IActionResult PostTrainingHistory()
        {
            return Ok();
        }

        [HttpPost("/weight")]
        public IActionResult PostWeightHistory()
        {
            return Ok();
        }

        [HttpGet("/training")]
        public IActionResult GetTrainingHistory()
        {
            return Ok();
        }


        [HttpGet("/weight")]
        public IActionResult GetWeightHistory()
        {
            return Ok();
        }
    }
}
