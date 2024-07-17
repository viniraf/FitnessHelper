using FitnessHelper.Models.Food;

namespace FitnessHelper.Repositories.Implementations;

public class FoodRepository : IFoodRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public FoodRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext; 
    }

    public async Task PostAsync(FoodModel foodModel)
    {
        await _applicationDbContext.Foods.AddAsync(foodModel);
        await _applicationDbContext.SaveChangesAsync();
    }

    public async Task<List<FoodModel>> GetAllAsync()
    {
        List<FoodModel> foods = await _applicationDbContext.Foods.ToListAsync();
        
        return foods;
    }

    public async Task<FoodModel> GetByIdAsync(int id)
    {
        FoodModel? food = await _applicationDbContext.Foods.FirstOrDefaultAsync(f => f.Id == id);

        return food;
    }

    public async Task PatchAsync(FoodModel foodModel)
    {
        _applicationDbContext.Foods.Update(foodModel);
        await _applicationDbContext.SaveChangesAsync();
    }
}
