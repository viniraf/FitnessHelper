using FitnessHelper.Data;
using FitnessHelper.Models;
using FitnessHelper.Repositories.Interfaces;

namespace FitnessHelper.Repositories.Implementations;

public class UserRepository : IUserRepository
{

    private readonly ApplicationDbContext _applicationDbContext;

    public UserRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public void Register(UserModel userModel)
    {
        _applicationDbContext.Users.Add(userModel);
        _applicationDbContext.SaveChanges();
    }

    public UserModel GetByUsername(string username)
    {
        UserModel user = _applicationDbContext.Users.FirstOrDefault(x => x.Username == username);

        if (user == null)
        {
            return new UserModel();
        }

        return user;
    }

}
