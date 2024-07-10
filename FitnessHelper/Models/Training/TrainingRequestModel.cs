namespace FitnessHelper.Models.Training;

public class TrainingRequestModel
{
    public string TrainingTitle { get; set; } = string.Empty;

    public DateOnly CreateDate { get; set; }
}