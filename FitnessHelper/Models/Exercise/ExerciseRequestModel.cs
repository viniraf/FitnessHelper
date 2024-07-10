namespace FitnessHelper.Models.Exercise;

public class ExerciseRequestModel
{
    public string ExerciseTitle { get; set; } = string.Empty;

    public int TrainingId { get; set; }

    public int QtySets { get; set; }

    public int QtyReps { get; set; }
}