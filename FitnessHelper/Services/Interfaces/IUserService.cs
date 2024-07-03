using FitnessHelper.Enums;
using FitnessHelper.Models;

namespace FitnessHelper.Services.Interfaces;

public interface IUserService
{
    public void Register(UserRegisterModel userRegisterModel);

    public UserModel GetByUsername(string username);

    public LoginResult Login(UserLoginModel userLoginModel);

    public string GenerateToken(int userId);
}
