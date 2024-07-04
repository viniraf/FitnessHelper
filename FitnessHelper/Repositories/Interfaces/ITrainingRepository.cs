using FitnessHelper.Enums;
using FitnessHelper.Models;

namespace FitnessHelper.Repositories.Interfaces;

public interface ITrainingRepository
{
    public List<TrainingModel> GetAllByStatus(int userId, bool trainingIsActive);

    public TrainingModel GetById(int userId, int id);

    public void Create(TrainingModel trainingModel);

    public void Update(TrainingModel trainingModel);

    public List<ExerciseModel> GetAllExercisesByStatus(int userId, bool exerciseIsActive);
}
