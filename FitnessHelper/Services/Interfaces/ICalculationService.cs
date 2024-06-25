using FitnessHelper.Enums;

namespace FitnessHelper.Services.Interfaces;

public interface ICalculationService
{
    public int CalculateBasalMetabolicRate(Sex sex, double weight, double height, int age, ExerciseTimesPerWeek exerciseTimesPerWeek);
}
