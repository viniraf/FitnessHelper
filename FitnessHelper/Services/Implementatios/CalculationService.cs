using FitnessHelper.Dictionaries;
using FitnessHelper.Enums;
using FitnessHelper.Models;
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

    public MacronutrientCalculationModel CalculateMacronutrient(int basalMetabolicRate, double weight, Goal goal)
    {
        double goalBMR = 0;
        string goalString = "";

        SetValuesByGoal(basalMetabolicRate, goal, ref goalBMR, ref goalString);

        double totalCal = goalBMR;

        double protGrams = weight * 1.8;

        totalCal = totalCal - (protGrams * 4);

        double fatGrams = weight;

        totalCal = totalCal - (fatGrams * 8);

        double carbGrams = totalCal / 4;

        MacronutrientCalculationModel macronutrientCalculationModel = new MacronutrientCalculationModel(basalMetabolicRate, goalString, goalBMR, protGrams, carbGrams, fatGrams);

        return macronutrientCalculationModel;
    }

    private static void SetValuesByGoal(int basalMetabolicRate, Goal goal, ref double goalBMR, ref string goalString)
    {
        if (goal == Goal.GainWeight)
        {
            goalBMR = basalMetabolicRate + 500;
            goalString = "Gain Weight";
        }
        else if (goal == Goal.LoseWeight)
        {
            goalBMR = basalMetabolicRate - 500;
            goalString = "Lose Weight";
        }
        else if (goal == Goal.MaintainWeight)
        {
            goalBMR = basalMetabolicRate;
            goalString = "Maintain Weight";
        }
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
