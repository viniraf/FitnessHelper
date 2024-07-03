using System.Text.Json.Serialization;

namespace FitnessHelper.Models;

public class WeighingHistoryModel
{
    public int Id { get; set; }

    public double Weight { get; set; }

    public DateOnly Date { get; set; }

    [JsonIgnore]
    public int UserId { get; set; }
}
