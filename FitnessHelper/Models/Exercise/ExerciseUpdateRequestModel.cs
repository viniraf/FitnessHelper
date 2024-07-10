namespace FitnessHelper.Models.Exercise;

public class ExerciseUpdateRequestModel
{
    public string ExerciseTitle { get; set; } = string.Empty;

    public int TrainingId { get; set; }

    public int QtySets { get; set; }

    public int QtyReps { get; set; }

    public bool IsActive { get; set; }
}