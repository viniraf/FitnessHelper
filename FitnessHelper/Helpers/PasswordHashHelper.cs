using System.Security.Cryptography;
using System.Text;

namespace FitnessHelper.Helpers;

public static class PasswordHashHelper
{
    public static string CreateHash(string password)
    {
        using (var sha1 = SHA1.Create())
        {
            var hashedBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }

    public static bool VerifyHash(string password, string savedHash)
    {
        string inputHash = CreateHash(password);
        return inputHash == savedHash;
    }
}
