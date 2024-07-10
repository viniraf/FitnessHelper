using FitnessHelper.Models;

namespace FitnessHelper.Services.Interfaces;

public interface IExerciseService
{
    public Task<ExerciseModel> GetByIdAsync(int userId, int id);

    public Task AddExerciseAsync(int userId, ExerciseRequestModel exerciseRequestModel);

    public Task UpdateExerciseAsync(int userId, int id, ExerciseUpdateRequestModel exerciseUpdateRequestModel);
}
