namespace FitnessHelper.Controllers;

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

        await _historyService.AddTrainingHistoryAsync(userId, trainingHistoryRequest);

        return NoContent();
    }

    [HttpPost("weight")]
    [Authorize]
    public async Task<IActionResult> PostWeightHistory(WeighingHistoryRequestModel weighingHistoryRequest)
    {
        if (weighingHistoryRequest == null)
        {
            return BadRequest();
        }

        int userId = int.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);

        await _historyService.AddWeighingHistoryAsync(userId, weighingHistoryRequest);

        return NoContent();
    }

    [HttpGet("training")]
    [Authorize]
    public async Task<IActionResult> GetTrainingHistory()
    {
        int userId = int.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);

        List<TrainingHistoryModel> trainingHistories = await _historyService.GetTrainingHistoriesAsync(userId);

        return Ok(trainingHistories);
    }


    [HttpGet("weight")]
    [Authorize]
    public async Task<IActionResult> GetWeightHistory()
    {
        int userId = int.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);

        List<WeighingHistoryModel> weighingHistories = await _historyService.GetWeighingHistoriesAsync(userId);

        return Ok(weighingHistories);
    }
}