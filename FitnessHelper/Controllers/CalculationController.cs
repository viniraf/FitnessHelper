using FitnessHelper.Enums;
using FitnessHelper.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TGolla.Swashbuckle.AspNetCore.SwaggerGen;

namespace FitnessHelper.Controllers;

[Route("api/calculation")]
[SwaggerControllerOrder(2)]
[ApiController]
public class CalculationController : ControllerBase
{
    private readonly ICalculationService _basalMetabolicRateService;

    public CalculationController(ICalculationService basalMetabolicRateService)
    {
        _basalMetabolicRateService = basalMetabolicRateService;
    }


    [HttpGet("basal-metabolic-rate")]
    public IActionResult BasalMetabolicRate([FromQuery] Sex sex, double weight, double height, int age, [FromQuery] ExerciseTimesPerWeek exerciseTimesPerWeek)
    {
        int roundedBasalMetabolicRate = _basalMetabolicRateService.CalculateBasalMetabolicRate(sex, weight, height, age, exerciseTimesPerWeek);
        return Ok($"Basal Metabolic Rate: {roundedBasalMetabolicRate}");
    }
}
