using FitnessHelper.Models;

namespace FitnessHelper.Repositories.Interfaces;

public interface ITrainingRepository
{
    public List<TrainingModel> GetAll(int userId);

    public TrainingModel GetById(int userId, int id);

    public void Create(TrainingModel trainingModel);

    public void Update(TrainingModel trainingModel);

    public List<ExerciseModel> GetAllExercises(int userId);
}
