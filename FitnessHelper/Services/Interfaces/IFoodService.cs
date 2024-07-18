using FitnessHelper.Models.Food;

namespace FitnessHelper.Services.Interfaces;

public interface IFoodService
{
    public Task PostAsync(FoodRequestModel foodRequestModel);

    public Task<List<FoodModel>> GetAllAsync();

    public Task<List<FoodModel>> GetAllByNameAsync(string name);

    public Task<FoodModel> GetByIdAsync(int id);

    public Task PatchAsync(int id, FoodRequestModel foodRequestModel);

}
