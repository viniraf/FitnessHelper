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

    public async Task RegisterAsync(UserRegisterModel userRegisterModel)
    {
        string hashedPassword = _passwordHashHelper.CreateHash(userRegisterModel.Password);

        UserModel newUser = new UserModel
        {
            Name = userRegisterModel.Name,
            Username = userRegisterModel.Username,
            PasswordHash = hashedPassword
        };

        await _userRepository.RegisterAsync(newUser);
    }

    public async Task<UserModel> GetByUsernameAsync(string username)
    {
        UserModel user = await _userRepository.GetByUsernameAsync(username);

        return user;
    }

    public async Task<LoginResult> LoginAsync(UserLoginModel userLoginModel)
    {
        UserModel passwordSavedHashModel = await _userRepository.GetByUsernameAsync(userLoginModel.Username);

        string passwordSavedHash = passwordSavedHashModel.PasswordHash;

        if (string.IsNullOrEmpty(passwordSavedHash))
        {
            return LoginResult.InvalidCredentials;
        }

        bool isInputPasswordCorrect = _passwordHashHelper.IsInputPasswordCorrect(userLoginModel.Password, passwordSavedHash);

        if (isInputPasswordCorrect == false)
        {
            return LoginResult.InvalidCredentials;
        }

        return LoginResult.ValidCredentials;
    }

    public string GenerateToken(int userId)
    {
        string token = _jwtHelper.GenerateToken(userId);

        return token;
    }
}