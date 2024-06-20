using FitnessHelper.Models;

namespace FitnessHelper.Repositories.Interfaces;

public interface IUserRepository
{
    public void Register(UserModel userModel);

    public UserModel GetByUsername(string username);
}
