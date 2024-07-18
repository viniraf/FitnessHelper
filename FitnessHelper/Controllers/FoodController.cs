using FitnessHelper.Models.Food;

namespace FitnessHelper.Controllers;

[SwaggerControllerOrder(3)]
[Route("api/food")]
[ApiController]
public class FoodController : ControllerBase
{
    private readonly IFoodService _foodService;

    public FoodController(IFoodService foodService)
    {
        _foodService = foodService;
    }

    [HttpPost]
    public async Task<IActionResult> Post(FoodRequestModel foodRequestModel)
    {
        if (foodRequestModel == null)
        {
            return BadRequest();
        }

        await _foodService.PostAsync(foodRequestModel);

        return Created();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string name = "")
    {
        List<FoodModel> foods = new List<FoodModel>();

        if (string.IsNullOrEmpty(name))
        {
            foods = await _foodService.GetAllAsync();
        }
        else
        {
            foods = await _foodService.GetAllByNameAsync(name);
        }

        return Ok(foods);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(int id, FoodRequestModel foodRequestModel)
    {
        if (foodRequestModel == null)
        {
            return BadRequest();
        }

        FoodModel food = await _foodService.GetByIdAsync(id);

        if (food == null)
        {
            return NotFound();
        }

        await _foodService.PatchAsync(id, foodRequestModel);

        return NoContent();
    }

}
