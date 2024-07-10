using FitnessHelper.Models;

namespace FitnessHelper.Repositories.Interfaces;

public interface IHistoryRepository
{
    public Task AddTrainingHistoryAsync(TrainingHistoryModel trainingHistory);

    public Task<List<TrainingHistoryModel>> GetTrainingHistoriesAsync(int userId);

    public Task AddWeighingHistoryAsync(WeighingHistoryModel weighingHistory);

    public Task<List<WeighingHistoryModel>> GetWeighingHistoriesAsync(int userId);
}
