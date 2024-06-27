using FitnessHelper.Models;
using FitnessHelper.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        private readonly ITrainingService _trainingService;

        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }


        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            List<TrainingModel> trainings = _trainingService.GetAll();
            return Ok(trainings);
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            TrainingModel training = _trainingService.GetById(id);

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

            _trainingService.Create(trainingRequestModel);

            return Ok("Training was created successfully");
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, TrainingUpdateRequestModel trainingUpdateRequestModel)
        {
            TrainingModel training = _trainingService.GetById(id);

            if (training == null)
            {
                return NotFound($"There is no training with Id {id}");
            }

            _trainingService.Update(id, trainingUpdateRequestModel);

            return Ok($"Update training by id: {id}");
        }

    }
}
