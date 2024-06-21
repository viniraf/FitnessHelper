using FitnessHelper.Enums;
using FitnessHelper.Helpers;
using FitnessHelper.Models;
using FitnessHelper.Repositories.Interfaces;
using FitnessHelper.Services.Interfaces;

namespace FitnessHelper.Services.Implementatios;

public class UserService : IUserService
{

    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void Register(UserRegisterModel userRegisterModel)
    {
        var hashedPassword = PasswordHashHelper.CreateHash(userRegisterModel.Password);

        var newUser = new UserModel
        {
            Name = userRegisterModel.Name,
            Username = userRegisterModel.Username,
            PasswordHash = hashedPassword
        };

        _userRepository.Register(newUser);
    }

    public LoginResult Login(UserLoginModel userLoginModel)
    {
        throw new NotImplementedException();
    }


}
