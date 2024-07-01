namespace FitnessHelper.Models;

public class ExerciseRequestModel
{
    public string Exercise { get; set; } = string.Empty;

    public int QtySets { get; set; }

    public int QtyReps { get; set; }

    public bool IsActive { get; set; }
}
