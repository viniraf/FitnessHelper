namespace FitnessHelper.Helpers.Interfaces;

public interface IPasswordHashHelper
{
    public string CreateHash(string password);

    public bool IsInputPasswordCorrect(string inputPassword, string savedPasswordHash);
}
