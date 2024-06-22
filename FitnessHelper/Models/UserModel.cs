namespace FitnessHelper.Models;

public class UserModel
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Username { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public UserModel()
    {
        
    }
}
