using FitnessHelper.Dictionaries;
using FitnessHelper.Enums;
using FitnessHelper.Services.Interfaces;

namespace FitnessHelper.Services.Implementatios;

public class CalculationService : ICalculationService
{
    public int CalculateBasalMetabolicRate(Sex sex, double weight, double height, int age, ExerciseTimesPerWeek exerciseTimesPerWeek)
    {
        double basalMetabolicRate = 0;

        if (sex == Sex.Male) 
        {
            basalMetabolicRate = CalculateMaleBasalMetabolicRate(weight, height, age, exerciseTimesPerWeek);
        }

        if (sex == Sex.Female)
        {
            basalMetabolicRate = CalculateFemaleBasalMetabolicRate(weight, height, age, exerciseTimesPerWeek);
        }

        double multiplicativeFactor = ExerciseMultiplicativeFactors.ExerciseMultiplicativeFactorsMap[Convert.ToInt32(exerciseTimesPerWeek)];

        basalMetabolicRate *= multiplicativeFactor;

        int roundedBasalMetabolicRate = (int)Math.Round(basalMetabolicRate, MidpointRounding.AwayFromZero);

        return roundedBasalMetabolicRate;
    }

    private double CalculateMaleBasalMetabolicRate(double weight, double height, int age, ExerciseTimesPerWeek exerciseTimesPerWeek)
    {
        double maleBasalMetabolicRate = (10 * weight) + (6.25 * height) - (5 * age) + 5;
        
        return maleBasalMetabolicRate;
    }

    private double CalculateFemaleBasalMetabolicRate(double weight, double height, int age, ExerciseTimesPerWeek exerciseTimesPerWeek)
    {
        double femaleBasalMetabolicRate = (10 * weight) + (6.25 * height) - (5 * age) + 161;

        return femaleBasalMetabolicRate;
    }
}
