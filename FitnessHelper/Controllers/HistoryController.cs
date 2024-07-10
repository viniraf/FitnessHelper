using FitnessHelper.Models;
using FitnessHelper.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TGolla.Swashbuckle.AspNetCore.SwaggerGen;

namespace FitnessHelper.Controllers
{
    [Route("api/history")]
    [SwaggerControllerOrder(7)]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService _historyService;

        private readonly ITrainingService _trainingService;

        public HistoryController(IHistoryService historyService, ITrainingService trainingService)
        {
            _historyService = historyService;
            _trainingService = trainingService;

        }

        [HttpPost("training")]
        [Authorize]
        public async Task<IActionResult> PostTrainingHistory(TrainingHistoryRequestModel trainingHistoryRequest)
        {
            if (trainingHistoryRequest == null)
            {
                return BadRequest();
            }

            int userId = int.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);

            TrainingModel training = await _trainingService.GetByIdAsync(userId, trainingHistoryRequest.TrainingId);

            if (training == null)
            {
                return NotFound();
            }

            _historyService.AddTrainingHistory(userId, trainingHistoryRequest);

            return NoContent();
        }

        [HttpPost("weight")]
        [Authorize]
        public IActionResult PostWeightHistory(WeighingHistoryRequestModel weighingHistoryRequest)
        {
            if (weighingHistoryRequest == null)
            {
                return BadRequest();
            }

            int userId = int.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);

            _historyService.AddWeighingHistory(userId, weighingHistoryRequest);

            return NoContent();
        }

        [HttpGet("training")]
        [Authorize]
        public IActionResult GetTrainingHistory()
        {
            int userId = int.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);

            List<TrainingHistoryModel> trainingHistories = _historyService.GetTrainingHistories(userId);

            return Ok(trainingHistories);
        }


        [HttpGet("weight")]
        [Authorize]
        public IActionResult GetWeightHistory()
        {
            int userId = int.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);

            List<WeighingHistoryModel> weighingHistories = _historyService.GetWeighingHistories(userId);

            return Ok(weighingHistories);
        }
    }
}
