using System.Text.Json.Serialization;

namespace FitnessHelper.Models;

public class TrainingModel
{
    public int Id { get; set; }

    public string TrainingTitle { get; set; } = string.Empty;

    public DateOnly CreateDate { get; set; }

    public bool IsActive { get; set; }

    [JsonIgnore]
    public int UserId { get; set; }

    public List<ExerciseModel> Exercises { get; set; }

    [JsonIgnore]
    public List<TrainingHistoryModel> TrainingHistories { get; set; }

    public TrainingModel()
    {
        
    }
}
