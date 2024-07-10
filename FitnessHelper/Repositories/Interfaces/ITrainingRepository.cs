using FitnessHelper.Enums;
using FitnessHelper.Models;

namespace FitnessHelper.Repositories.Interfaces;

public interface ITrainingRepository
{
    public Task<List<TrainingModel>> GetAllByStatusAsync(int userId, bool trainingIsActive);

    public Task<TrainingModel> GetByIdAsync(int userId, int id);

    public Task CreateAsync(TrainingModel trainingModel);

    public Task UpdateAsync(TrainingModel trainingModel);

    public Task<List<ExerciseModel>> GetAllExercisesByStatusAsync(int userId, bool exerciseIsActive);
}
