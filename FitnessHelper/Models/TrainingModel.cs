using System.Text.Json.Serialization;

namespace FitnessHelper.Models;

public class TrainingModel
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public DateTime CreateDate { get; set; }

    public bool IsActive { get; set; }

    // Navigation property
    public List<ExerciseModel> Exercises { get; set; }

    [JsonIgnore]
    public List<TrainingHistoryModel> TrainingHistories { get; set; }

    public TrainingModel()
    {
        
    }
}
