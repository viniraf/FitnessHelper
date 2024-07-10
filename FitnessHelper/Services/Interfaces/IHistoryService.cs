using FitnessHelper.Models;

namespace FitnessHelper.Services.Interfaces;

public interface IHistoryService
{
    public Task AddTrainingHistoryAsync(int userId, TrainingHistoryRequestModel trainingHistoryRequest);

    public Task<List<TrainingHistoryModel>> GetTrainingHistoriesAsync(int userId);

    public Task AddWeighingHistoryAsync(int userId, WeighingHistoryRequestModel weighingHistoryRequest);

    public Task<List<WeighingHistoryModel>> GetWeighingHistoriesAsync(int userId);
}
