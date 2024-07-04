using FitnessHelper.Enums;
using FitnessHelper.Models;

namespace FitnessHelper.Services.Interfaces;

public interface ITrainingService
{
    public List<TrainingModel> GetAllByStatus(int userId, bool trainingIsActive, bool exericiseIsActive);

    public TrainingModel GetById(int userId, int id);

    public void Create(int userId, TrainingRequestModel trainingRequestModel);

    public void Update(int userId, int id, TrainingUpdateRequestModel trainingUpdateRequestModel);
}
