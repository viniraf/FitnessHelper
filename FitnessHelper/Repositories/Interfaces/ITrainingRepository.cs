using FitnessHelper.Models;

namespace FitnessHelper.Repositories.Interfaces;

public interface ITrainingRepository
{
    public Task<TrainingModel> GetAll();

    public Task<TrainingModel> GetById(int id);

    public void Create(TrainingModel trainingModel);

    public void Update(TrainingModel trainingModel);
}
