using FitnessHelper.Models;

namespace FitnessHelper.Repositories.Interfaces;

public interface ITrainingRepository
{
    public List<TrainingModel> GetAll();

    public TrainingModel GetById(int id);

    public void Create(TrainingModel trainingModel);

    public void Update(TrainingModel trainingModel);

    public List<ExerciseModel> GetAllExercises();
}
