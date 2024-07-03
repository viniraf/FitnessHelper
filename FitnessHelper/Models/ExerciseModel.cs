using System.Text.Json.Serialization;

namespace FitnessHelper.Models;

public class ExerciseModel
{
    public int Id { get; set; }

    public string Exercise { get; set; } = string.Empty;

    public int TrainingId { get; set; }

    public int QtySets { get; set; }

    public int QtyReps { get; set; }

    public bool IsActive { get; set; }

    [JsonIgnore]
    public int UserId { get; set; }

    // Navigation property

    [JsonIgnore]
    public TrainingModel Training { get; set; }
}
