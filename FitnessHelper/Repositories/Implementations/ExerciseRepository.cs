namespace FitnessHelper.Repositories.Implementations;

public class ExerciseRepository : IExerciseRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public ExerciseRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<ExerciseModel> GetByIdAsync(int userId, int id)
    {
        ExerciseModel? exercise = await _applicationDbContext.Exercises.FirstOrDefaultAsync(x => x.Id == id);

        return exercise;
    }

    public async Task AddExerciseAsync(ExerciseModel exerciseModel)
    {
        await _applicationDbContext.Exercises.AddAsync(exerciseModel);
        await _applicationDbContext.SaveChangesAsync();
    }

    public async Task UpdateExerciseAsync(ExerciseModel exerciseModel)
    {
        _applicationDbContext.Exercises.Update(exerciseModel);
        await _applicationDbContext.SaveChangesAsync();
    }
}