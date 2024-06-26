using FitnessHelper.Enums;
using FitnessHelper.Models;
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
    private readonly ICalculationService _calculationService;

    public CalculationController(ICalculationService calculationService)
    {
        _calculationService = calculationService;
    }

    [HttpGet("basal-metabolic-rate")]
    public IActionResult BasalMetabolicRate([FromQuery] Sex sex, double weight, double height, int age, [FromQuery] ExerciseTimesPerWeek exerciseTimesPerWeek)
    {
        int roundedBasalMetabolicRate = _calculationService.CalculateBasalMetabolicRate(sex, weight, height, age, exerciseTimesPerWeek);
        return Ok($"Basal Metabolic Rate: {roundedBasalMetabolicRate}");
    }

    [HttpGet("macronutrient")]
    public IActionResult Macronutrient([FromQuery] int basalMetabolicRate, [FromQuery] double weight, [FromQuery] Goal goal)
    {
        MacronutrientCalculationModel macronutrientCalculationModel = _calculationService.CalculateMacronutrient(basalMetabolicRate, weight, goal);
        return Ok(macronutrientCalculationModel);
    }
}
