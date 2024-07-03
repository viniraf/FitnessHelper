using FitnessHelper.Models;

namespace FitnessHelper.Repositories.Interfaces;

public interface IHistoryRepository
{
    public void AddTrainingHistory(TrainingHistoryModel trainingHistory);

    public List<TrainingHistoryModel> GetTrainingHistories(int userId);

    public void AddWeighingHistory(WeighingHistoryModel weighingHistory);

    public List<WeighingHistoryModel> GetWeighingHistories(int userId);
}
