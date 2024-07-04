using FitnessHelper.Enums;
using FitnessHelper.Models;
using FitnessHelper.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Http;
using System.Security.Claims;
using TGolla.Swashbuckle.AspNetCore.SwaggerGen;

namespace FitnessHelper.Controllers
{
    [Route("api/training")]
    [SwaggerControllerOrder(3)]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingService _trainingService;

        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }


        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] bool trainingIsActive = true, bool exerciseIsActive = true)
        {
            int userId = int.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);

            List<TrainingModel> trainings = _trainingService.GetAllByStatus(userId, trainingIsActive, exerciseIsActive);

            return Ok(trainings);
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            int userId = int.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);

            TrainingModel training = _trainingService.GetById(userId, id);

            if (training == null)
            {
                return NotFound($"There is no training with Id {id}");
            }

            return Ok(training);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post(TrainingRequestModel trainingRequestModel)
        {
            if (trainingRequestModel == null)
            {
                return BadRequest("Fill in the information correctly");
            }

            int userId = int.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);

            _trainingService.Create(userId, trainingRequestModel);

            return Ok("Training was created successfully");
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, TrainingUpdateRequestModel trainingUpdateRequestModel)
        {
            int userId = int.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);

            TrainingModel training = _trainingService.GetById(userId, id);

            if (training == null)
            {
                return NotFound($"There is no training with Id {id}");
            }
            
            _trainingService.Update(userId, id, trainingUpdateRequestModel);

            return Ok($"Update training by id: {id}");
        }

    }
}
