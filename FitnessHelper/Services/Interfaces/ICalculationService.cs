using FitnessHelper.Enums;
using FitnessHelper.Models;

namespace FitnessHelper.Services.Interfaces;

public interface ICalculationService
{
    public int CalculateBasalMetabolicRate(Sex sex, double weight, double height, int age, ExerciseTimesPerWeek exerciseTimesPerWeek);

    public MacronutrientCalculationModel CalculateMacronutrient(int basalMetabolicRate, double weight, Goal goal);
}
