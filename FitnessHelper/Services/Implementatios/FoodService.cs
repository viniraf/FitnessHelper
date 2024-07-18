using FitnessHelper.Models.Food;

namespace FitnessHelper.Services.Implementatios;

public class FoodService : IFoodService
{
    private readonly IFoodRepository _foodRepository;

    public FoodService(IFoodRepository foodRepository)
    {
        _foodRepository = foodRepository;
    }

    public async Task PostAsync(FoodRequestModel foodRequestModel)
    {
        double qtyCal = (foodRequestModel.QtyProt * 4) + (foodRequestModel.QtyCarb * 4) + (foodRequestModel.QtyFat * 7);

        FoodModel foodModel = new FoodModel
        { 
            Name = foodRequestModel.Name,
            UnitOfMeasurement = foodRequestModel.UnitOfMeasurement,
            Qty = foodRequestModel.Qty,
            QtyProt = foodRequestModel.QtyProt,
            QtyCarb = foodRequestModel.QtyCarb,
            QtyFat = foodRequestModel.QtyFat,
            QtyCal = qtyCal,
        };

        await _foodRepository.PostAsync(foodModel);
    }

    public async Task<List<FoodModel>> GetAllAsync()
    {
        List<FoodModel> foods = await _foodRepository.GetAllAsync();

        if (foods.Count == 0)
        {
            return new List<FoodModel>();
        }

        return foods;
    }

    public async Task<FoodModel> GetByIdAsync(int id)
    {
        FoodModel food = await _foodRepository.GetByIdAsync(id);

        return food;
    }

    public async Task<List<FoodModel>> GetAllByNameAsync(string name)
    {
        string lowerName = name.ToLower();

        var foods = await _foodRepository.GetAllByNameAsync(lowerName);

        return foods;
    }

    public async Task PatchAsync(int id, FoodRequestModel foodRequestModel)
    {

        FoodModel food = await _foodRepository.GetByIdAsync(id);

        double qtyCal = (foodRequestModel.QtyProt * 4) + (foodRequestModel.QtyCarb * 4) + (foodRequestModel.QtyFat * 7);

        food.Name = foodRequestModel.Name;
        food.UnitOfMeasurement = foodRequestModel.UnitOfMeasurement;
        food.Qty = foodRequestModel.Qty;
        food.QtyProt = foodRequestModel.QtyProt;
        food.QtyCarb = foodRequestModel.QtyCarb;
        food.QtyFat = foodRequestModel.QtyFat;
        food.QtyCal = qtyCal;

        await _foodRepository.PatchAsync(food);
    }
}
