namespace FitnessHelper.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Sex
{
    Male,
    Female
}