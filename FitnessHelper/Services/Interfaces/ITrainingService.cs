using FitnessHelper.Models;

namespace FitnessHelper.Services.Interfaces;

public interface ITrainingService
{
    public List<TrainingModel> GetAll();

    public TrainingModel GetById(int id);

    public void Create(TrainingRequestModel trainingRequestModel);

    public void Update(int id, TrainingUpdateRequestModel trainingUpdateRequestModel);
}
