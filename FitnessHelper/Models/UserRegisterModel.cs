namespace FitnessHelper.Models;

public class UserRegisterModel
{
    public string Name { get; set; } = string.Empty;

    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public UserRegisterModel()
    {
        
    }
}
