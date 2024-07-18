using FitnessHelper.Models.Food;

namespace FitnessHelper.Repositories.Interfaces;

public interface IFoodRepository
{
    public Task PostAsync(FoodModel foodModel);

    public Task<List<FoodModel>> GetAllAsync();

    public Task<List<FoodModel>> GetAllByNameAsync(string lowerName);

    public Task<FoodModel> GetByIdAsync(int id);

    public Task PatchAsync(FoodModel foodModel);
}
