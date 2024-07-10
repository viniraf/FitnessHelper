namespace FitnessHelper.Helpers.Implementations;

public class PasswordHashHelper : IPasswordHashHelper
{
    public string CreateHash(string password)
    {
        using (SHA1 sha1 = SHA1.Create())
        {
            byte[] hashedBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }

    public bool IsInputPasswordCorrect(string inputPassword, string savedPasswordHash)
    {
        string inputPasswordHash = CreateHash(inputPassword);
        return inputPasswordHash == savedPasswordHash;
    }
}