using FitnessHelper.Models;

namespace FitnessHelper.Services.Interfaces;

public interface ITrainingService
{
    public Task<TrainingModel> GetAll();

    public Task<TrainingModel> GetById(int id);

    public void Create(TrainingModel trainingModel);

    public void Update(TrainingModel trainingModel);
}
