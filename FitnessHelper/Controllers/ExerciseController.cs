using FitnessHelper.Models;
using FitnessHelper.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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

    [HttpPost]
    public IActionResult AddExercise(ExerciseRequestModel exerciseRequestModel)
    {
        if (exerciseRequestModel == null)
        {
            return BadRequest("Fill in the information correctly");
        }

        int userId = int.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);

        _exerciseService.AddExercise(userId, exerciseRequestModel);

        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateExercise(int id, ExerciseRequestModel exerciseRequestModel)
    {
        if (exerciseRequestModel == null)
        {
            return BadRequest("Fill in the information correctly");
        }

        int userId = int.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);

        ExerciseModel exercise = _exerciseService.GetById(userId, id);

        if (exercise == null)
        {
            return NotFound();
        }

        _exerciseService.UpdateExercise(userId, id, exerciseRequestModel);

        return NoContent();
    }
}
