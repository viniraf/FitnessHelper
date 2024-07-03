using FitnessHelper.Data;
using FitnessHelper.Models;
using FitnessHelper.Repositories.Interfaces;

namespace FitnessHelper.Repositories.Implementations;

public class ExerciseRepository : IExerciseRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public ExerciseRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public ExerciseModel GetById(int userId, int id)
    {
        var exercise = _applicationDbContext.Exercises.FirstOrDefault(x => x.Id == id);

        return exercise;
    }

    public void AddExercise(ExerciseModel exerciseModel)
    {
        _applicationDbContext.Exercises.Add(exerciseModel);
        _applicationDbContext.SaveChanges();
    }

    public void UpdateExercise(ExerciseModel exerciseModel)
    {
        _applicationDbContext.Update(exerciseModel);
        _applicationDbContext.SaveChanges();
    }
}
