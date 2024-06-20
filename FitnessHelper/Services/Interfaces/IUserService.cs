using FitnessHelper.Enums;
using FitnessHelper.Models;

namespace FitnessHelper.Services.Interfaces;

public interface IUserService
{
    public void Register(UserRegisterModel userRegisterModel);

    public LoginResult Login(UserLoginModel userLoginModel);
}
