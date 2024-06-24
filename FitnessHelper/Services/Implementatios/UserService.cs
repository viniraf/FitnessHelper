using FitnessHelper.Enums;
using FitnessHelper.Helpers.Implementations;
using FitnessHelper.Helpers.Interfaces;
using FitnessHelper.Models;
using FitnessHelper.Repositories.Interfaces;
using FitnessHelper.Services.Interfaces;

namespace FitnessHelper.Services.Implementatios;

public class UserService : IUserService
{

    private readonly IUserRepository _userRepository;
    private readonly IJwtHelper _jwtHelper;
    private readonly IPasswordHashHelper _passwordHashHelper;


    public UserService(IUserRepository userRepository, IPasswordHashHelper passwordHashHelper,IJwtHelper jwtHelper)
    {
        _userRepository = userRepository;
        _passwordHashHelper = passwordHashHelper;
        _jwtHelper = jwtHelper;

    }

    public void Register(UserRegisterModel userRegisterModel)
    {
        string hashedPassword = _passwordHashHelper.CreateHash(userRegisterModel.Password);

        UserModel newUser = new UserModel
        {
            Name = userRegisterModel.Name,
            Username = userRegisterModel.Username,
            PasswordHash = hashedPassword
        };

        _userRepository.Register(newUser);
    }

    public LoginResult Login(UserLoginModel userLoginModel)
    {
        string? passwordSavedHash = _userRepository.GetByUsername(userLoginModel.Username).PasswordHash;

        if (string.IsNullOrEmpty(passwordSavedHash))
        {
            return LoginResult.UserNotFound;
        }

        bool isInputPasswordCorrect = _passwordHashHelper.IsInputPasswordCorrect(userLoginModel.Password, passwordSavedHash);

        if (isInputPasswordCorrect == false)
        {
            return LoginResult.InvalidPassword;
        }

        return LoginResult.ValidLogin;
    }

    public string GenerateToken(string username)
    {
        string token = _jwtHelper.GenerateToken(username);
        return token;
    }
}
