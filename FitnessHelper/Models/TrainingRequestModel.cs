namespace FitnessHelper.Models;

public class TrainingRequestModel
{
    public string Title { get; set; } = string.Empty;

    public DateTime CreateDate { get; set; }

    public bool IsActive { get; set; }
}
