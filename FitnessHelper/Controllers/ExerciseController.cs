﻿namespace FitnessHelper.Controllers;

[Route("api/exercise")]
[SwaggerControllerOrder(5)]
[ApiController]
public class ExerciseController : ControllerBase
{
    private readonly IExerciseService _exerciseService;

    public ExerciseController(IExerciseService exerciseService)
    {
        _exerciseService = exerciseService;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddExercise(ExerciseRequestModel exerciseRequestModel)
    {
        if (exerciseRequestModel == null)
        {
            return BadRequest();
        }

        int userId = int.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);

        await _exerciseService.AddExerciseAsync(userId, exerciseRequestModel);

        return Created();
    }

    [HttpPatch("{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateExercise(int id, ExerciseUpdateRequestModel exerciseUpdateRequestModel)
    {
        if (exerciseUpdateRequestModel == null)
        {
            return BadRequest("Fill in the information correctly");
        }

        int userId = int.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);

        ExerciseModel exercise = await _exerciseService.GetByIdAsync(userId, id);

        if (exercise == null)
        {
            return NotFound();
        }

        await _exerciseService.UpdateExerciseAsync(userId, id, exerciseUpdateRequestModel);

        return NoContent();
    }
}