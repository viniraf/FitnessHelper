namespace FitnessHelper.Models;

public class MacronutrientCalculationModel
{
    public int BasalMetabolicRate { get; set; } = 0;

    public string Goal { get; set; } = string.Empty;

    public double GoalBasalMetabolicRate { get; set; } = 0;

    public double ProtGrams { get; set; } = 0;

    public double CarbGrams { get; set; } = 0;

    public double FatGrams { get; set; } = 0;

    public MacronutrientCalculationModel()
    {
        
    }

    public MacronutrientCalculationModel(int basalMetabolicRate, string goal, double goalBasalMetabolicRate, double protGrams, double carbGrams, double fatGrams)
    {
        BasalMetabolicRate = basalMetabolicRate;
        Goal = goal;
        GoalBasalMetabolicRate = goalBasalMetabolicRate;
        ProtGrams = protGrams;
        CarbGrams = carbGrams;
        FatGrams = fatGrams;
    }
}
