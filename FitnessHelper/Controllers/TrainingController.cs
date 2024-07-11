namespace FitnessHelper.Controllers;

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
    public async Task<IActionResult> Get([FromQuery] bool trainingIsActive = true, bool exerciseIsActive = true)
    {
        int userId = int.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);

        List<TrainingModel> trainings = await _trainingService.GetAllByStatusAsync(userId, trainingIsActive, exerciseIsActive);

        return Ok(trainings);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> Get(int id)
    {
        int userId = int.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);

        TrainingModel training = await _trainingService.GetByIdAsync(userId, id);

        if (training == null)
        {
            return NotFound($"There is no training with Id {id}");
        }

        return Ok(training);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Post(TrainingRequestModel trainingRequestModel)
    {
        if (trainingRequestModel == null)
        {
            return BadRequest("Fill in the information correctly");
        }

        int userId = int.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);

        await _trainingService.CreateAsync(userId, trainingRequestModel);

        return Created();
    }

    [HttpPatch("{id}")]
    [Authorize]
    public async Task<IActionResult> Patch(int id, TrainingUpdateRequestModel trainingUpdateRequestModel)
    {
        int userId = int.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);

        TrainingModel training = await _trainingService.GetByIdAsync(userId, id);

        if (training == null)
        {
            return NotFound($"There is no training with Id {id}");
        }
        
        await _trainingService.UpdateAsync(userId, id, trainingUpdateRequestModel);

        return NoContent();
    }

}