namespace FitnessHelper.Models;

public class TrainingModel
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public DateTime CreateDate { get; set; }

    public bool IsActive { get; set; }

    public TrainingModel()
    {
        
    }
}
