namespace FitnessHelper.Models;

public class TrainingUpdateRequestModel
{
    public string TrainingTitle { get; set; } = string.Empty;

    public bool IsActive { get; set; }
}
