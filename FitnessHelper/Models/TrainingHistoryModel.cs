using System.Text.Json.Serialization;

namespace FitnessHelper.Models;

public class TrainingHistoryModel
{
    public int Id { get; set; }

    public DateOnly Date { get; set; }

    public int TrainingId { get; set; }

    public int UserId { get; set; }

    [JsonIgnore]
    public TrainingModel Training { get; set; }
}
