using FitnessHelper.Enums;
using FitnessHelper.Models;

namespace FitnessHelper.Services.Interfaces;

public interface IUserService
{
    public Task RegisterAsync(UserRegisterModel userRegisterModel);

    public Task<UserModel> GetByUsernameAsync(string username);

    public Task<LoginResult> LoginAsync(UserLoginModel userLoginModel);

    public string GenerateToken(int userId);
}
