namespace FitnessHelper.Models;

public class TrainingRequestModel
{
    public string TrainingTitle { get; set; } = string.Empty;

    public DateOnly CreateDate { get; set; }

    public bool IsActive { get; set; }
}
