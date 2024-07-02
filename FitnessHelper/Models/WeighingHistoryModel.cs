namespace FitnessHelper.Models;

public class WeighingHistoryModel
{
    public int Id { get; set; }

    public DateOnly Date { get; set; }

    public double Weight { get; set; }
}
