using FitnessHelper.Models;

namespace FitnessHelper.Repositories.Interfaces;

public interface IUserRepository
{
    public Task RegisterAsync(UserModel userModel);

    public Task<UserModel> GetByUsernameAsync(string username);
}
