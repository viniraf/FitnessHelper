using System.Text.Json.Serialization;

namespace FitnessHelper.Models;

public class ExerciseModel
{
    public int Id { get; set; }

    public string ExerciseTitle { get; set; } = string.Empty;

    public int TrainingId { get; set; }

    public int QtySets { get; set; }

    public int QtyReps { get; set; }

    public bool IsActive { get; set; }

    [JsonIgnore]
    public int UserId { get; set; }

    [JsonIgnore]
    public TrainingModel Training { get; set; }
}
