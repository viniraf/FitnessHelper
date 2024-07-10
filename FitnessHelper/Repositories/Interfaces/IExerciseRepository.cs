using FitnessHelper.Models;

namespace FitnessHelper.Repositories.Interfaces;

public interface IExerciseRepository
{
    public Task<ExerciseModel> GetByIdAsync(int userId, int id);

    public Task AddExerciseAsync(ExerciseModel exerciseModel);

    public Task UpdateExerciseAsync(ExerciseModel exerciseModel);
}
