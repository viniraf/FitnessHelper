using FitnessHelper.Models;

namespace FitnessHelper.Services.Interfaces;

public interface IHistoryService
{
    public void AddTrainingHistory(int userId, TrainingHistoryRequestModel trainingHistoryRequest);

    public List<TrainingHistoryModel> GetTrainingHistories(int userId);

    public void AddWeighingHistory(int userId, WeighingHistoryRequestModel weighingHistoryRequest);

    public List<WeighingHistoryModel> GetWeighingHistories(int userId);
}
