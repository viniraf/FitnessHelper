using FitnessHelper.Enums;

namespace FitnessHelper.Services.Interfaces;

public interface IBasalMetabolicRateService
{
    public int CalculateBasalMetabolicRate(Sex sex, double weight, double height, int age, ExerciseTimesPerWeek exerciseTimesPerWeek);
}
