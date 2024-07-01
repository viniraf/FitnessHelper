using FitnessHelper.Models;
using FitnessHelper.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TGolla.Swashbuckle.AspNetCore.SwaggerGen;

namespace FitnessHelper.Controllers;

[Route("api/exercise")]
[SwaggerControllerOrder(4)]
[ApiController]
public class ExerciseController : ControllerBase
{
    private readonly IExerciseService _exerciseService;

    public ExerciseController(IExerciseService exerciseService)
    {
        _exerciseService = exerciseService;
    }

    [HttpPost("{trainingId}")]
    public IActionResult AddExercise(int trainingId, ExerciseRequestModel exerciseRequestModel)
    {
        if (exerciseRequestModel == null)
        {
            return BadRequest("Fill in the information correctly");
        }

        _exerciseService.AddExercise(trainingId, exerciseRequestModel);

        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateExercise(int id, ExerciseRequestModel exerciseRequestModel)
    {
        if (exerciseRequestModel == null)
        {
            return BadRequest("Fill in the information correctly");
        }

        var exercise = _exerciseService.GetById(id);

        if (exercise == null)
        {
            return NotFound($"There is no exercise with Id {id}");
        }

        _exerciseService.UpdateExercise(id, exerciseRequestModel);

        return NoContent();
    }
}
