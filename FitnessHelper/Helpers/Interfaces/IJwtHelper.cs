namespace FitnessHelper.Helpers.Interfaces;

public interface IJwtHelper
{
    string GenerateToken(int userId);
}