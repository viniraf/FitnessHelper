using FitnessHelper.Enums;
using FitnessHelper.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FitnessHelper.Controllers;

[Route("api/basal-metabolic-rate")]
[ApiController]
public class BasalMetabolicRateController : ControllerBase
{
    private readonly IBasalMetabolicRateService _basalMetabolicRateService;

    public BasalMetabolicRateController(IBasalMetabolicRateService basalMetabolicRateService)
    {
        _basalMetabolicRateService = basalMetabolicRateService;
    }

    [SwaggerOperation(Tags = ["Basal Metabolic Rate"])]
    [HttpGet]
    public IActionResult BasalMetabolicRate([FromQuery] Sex sex, double weight, double height, int age, [FromQuery] ExerciseTimesPerWeek exerciseTimesPerWeek)
    {
        int roundedBasalMetabolicRate = _basalMetabolicRateService.CalculateBasalMetabolicRate(sex, weight, height, age, exerciseTimesPerWeek);
        return Ok($"Basal Metabolic Rate: {roundedBasalMetabolicRate}");
    }
}
