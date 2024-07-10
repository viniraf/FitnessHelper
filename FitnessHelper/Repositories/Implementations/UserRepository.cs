namespace FitnessHelper.Repositories.Implementations;

public class UserRepository : IUserRepository
{

    private readonly ApplicationDbContext _applicationDbContext;

    public UserRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task RegisterAsync(UserModel userModel)
    {
        await _applicationDbContext.Users.AddAsync(userModel);
        await _applicationDbContext.SaveChangesAsync();
    }

    public async Task<UserModel> GetByUsernameAsync(string username)
    {
        UserModel user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => x.Username == username);

        return user;
    }

}