using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TGolla.Swashbuckle.AspNetCore.SwaggerGen;

namespace FitnessHelper.Controllers
{
    [Route("api/training")]
    [SwaggerControllerOrder(3)]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Get all trainings");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok($"Get training by id: {id}");
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok("Create training");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            return Ok($"Update training by id: {id}");
        }
    }
}
